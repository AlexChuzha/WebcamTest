Imports System.ComponentModel
Imports System.Text
Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing
Imports PassportVision.Library.Sdk
Imports PassportVision.Library.Sdk.Recognition
Imports PassportVision.Library.Sdk.Settings
Imports PassportVision.Library.Sdk.Pictures
Imports System.Collections.ObjectModel
Imports PassportVision.Library.Sdk.General
Imports System.Threading.Tasks
Imports System.Net.Http
Imports Newtonsoft.Json
Imports TesseractOCR
Imports DevExpress.XtraEditors.Camera

Partial Public Class Form1

    Private pvService As IPassportVisionService

    Private _referenceFrame As Bitmap ' Эталонный фон (первый кадр)
    Private Property ReferenceFrame As Bitmap
        Get
            Return _referenceFrame
        End Get
        Set(value As Bitmap)
            _referenceFrame = value
        End Set
    End Property

    Private isDocumentDetected As Boolean = False ' Флаг для обнаружения документа
    Private previousFrame As Bitmap ' Предыдущий кадр для сравнения
    Private isStable As Boolean = False ' Флаг для обнаружения стабильности кадра
    Private stableTimer As Timer ' Таймер для определения стабильности
    Private stableThreshold As TimeSpan = TimeSpan.FromSeconds(2) ' Пороговое время для стабильности
    Private startTime As DateTime ' Время начала работы таймера
    Private stableTimeStart As DateTime = DateTime.MinValue

    Private Const StabilityDelay As Integer = 2000 ' Время стабильности в миллисекундах (2 секунды)
    Private isDocumentStable As Boolean = False

    Public Sub New()
        InitializeComponent()
        InitTimer()
    End Sub

    Private Sub InitTimer()
        ' Инициализация таймера
        stableTimer = New Timer()
        AddHandler stableTimer.Tick, AddressOf StableTimer_Tick
        stableTimer.Interval = 100 ' Проверяем каждые 100 мс
        stableTimer.Stop()
    End Sub

    Private Sub StableTimer_Tick(sender As Object, e As EventArgs)
        If Not isStable Then
            ' Проверяем, прошло ли достаточно времени
            If DateTime.Now - startTime >= stableThreshold Then
                isStable = True
                stableTimer.Stop()
                MessageBox.Show("Документ стабилен!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub InitCamera()

        ' Получаем текущий кадр
        Dim currentFrame As Bitmap = CameraControl1.TakeSnapshot

        If ReferenceFrame Is Nothing Then
            ' Сохраняем первый кадр как эталонный фон
            ReferenceFrame = CameraControl1.TakeSnapshot
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCameraTo90.ItemClick
        CameraControl1.RotateAngle = CameraControl1.RotateAngle + DevExpress.XtraEditors.Camera.RotateAngle.Rotate90
    End Sub

    Private Function ShowImageByteArray() As Byte()
        ' Загружаем изображение
        Dim image As Image = Image.FromFile("Images\RussianPassport.jpg")

        ' Преобразуем изображение в массив байт
        Dim byteArray As Byte() = ImageToByteArray(image)

        ' Теперь можно передать byteArray через API

        ' Если нужно увидеть размер массива байт
        Console.WriteLine($"Размер массива байт: {byteArray.Length} байт")

        ' Очистка ресурсов
        image.Dispose()
        Return byteArray
    End Function

    Private Function ImageToByteArray(ByVal image As Image) As Byte()
        ' Создаем поток в памяти
        Using memoryStream As New MemoryStream()
            ' Сохраняем изображение в поток в формате PNG (можно выбрать другой формат)
            image.Save(memoryStream, Imaging.ImageFormat.Png)

            ' Возвращаем массив байт из потока
            Return memoryStream.ToArray()
        End Using
    End Function

    Dim prevFrame As Bitmap

    Private Sub CameraControl1_CustomDrawFrame(sender As Object, e As CustomDrawFrameEventArgs) Handles CameraControl1.CustomDrawFrame
        If Not grabImage Then
            Return
        End If
        If ReferenceFrame Is Nothing Then
            ' Сохраняем первый кадр как эталонный фон
            ReferenceFrame = CameraControl1.TakeSnapshot
        End If


        If ReferenceFrame IsNot Nothing Then
            ' Получаем текущий кадр
            Dim currentFrame As Bitmap = e.CurrentFrame

            ' Сравниваем текущий кадр с эталонным фоном
            If DetectChanges(ReferenceFrame, currentFrame) Then
                ' Если обнаружены изменения, рисуем прямоугольник
                If Not isDocumentDetected Then
                    isDocumentDetected = True
                    'MessageBox.Show("Документ обнаружен!")
                End If

                'Документ обнаружен в кадре - теперь этот кадр надо сравнить, но не с эталонным,
                '   а с предыдущим кадром, на котором тоже был зафиксирован документ.
                '   Дополнительное условие - это сравнение должно проводиться только спустя пару секунд после того, как зафиксировано первое попадание документа в кадр

                If (DateTime.Now - stableTimeStart).TotalMilliseconds >= StabilityDelay Then
                    ' Документ стабилизирован
                    If DetectChanges(currentFrame, prevFrame, 0) Then
                        'stableTimeStart = DateTime.MinValue
                        isDocumentStable = False
                    Else
                        isDocumentStable = True
                        stableTimeStart = DateTime.Now
                    End If
                Else
                    ' ...
                End If

                If isDocumentStable Then
                    ' Рисуем прямоугольник
                    e.Cache.DrawRectangle(New Pen(Color.Green, 10),
                                          New Rectangle(New Point(10, 10),
                                                        New Drawing.Size(CameraControl1.Width - 20, CameraControl1.Height - 20)))
                Else
                    ' Рисуем прямоугольник
                    e.Cache.DrawRectangle(New Pen(Color.Red, 10),
                                          New Rectangle(New Point(10, 10),
                                                        New Drawing.Size(CameraControl1.Width - 20, CameraControl1.Height - 20)))
                End If

                stableTimeStart = DateTime.Now
                prevFrame = currentFrame
            Else
                ' Если изменений нет, сбрасываем флаг
                isDocumentDetected = False
                isDocumentStable = False
                stableTimeStart = DateTime.MinValue
                prevFrame = Nothing
            End If
        End If
    End Sub

    Private Function DetectChanges(image1 As Bitmap, image2 As Bitmap, Optional threshold As Integer = 50) As Boolean
        If image1 Is Nothing OrElse image2 Is Nothing Then Return True
        '
        ' Проверяем, совпадают ли размеры изображений
        If image1.Width <> image2.Width OrElse
           image1.Height <> image2.Height Then
            'Захватываем новый снапшот, с новым разрешением экрана
            ReferenceFrame = CameraControl1.TakeSnapshot
            Return False
        End If
        '
        'Dim threshold As Integer = 50 ' Пороговое значение для обнаружения изменений
        Dim differenceCount As Integer = 0
        '
        ' Определяем вертикальные границы центральной части
        Dim centerY As Integer = image1.Height \ 2
        Dim verticalRange As Integer = image1.Height \ 50 ' Рассматриваем 1/4 высоты от центра
        Dim topBoundary As Integer = Math.Max(0, centerY - verticalRange)
        Dim bottomBoundary As Integer = Math.Min(image1.Height - 1, centerY + verticalRange)
        '
        For y As Integer = topBoundary To bottomBoundary
            For x As Integer = image1.Width / 2 To image1.Width - 1
                Dim pixel1 As Color = image1.GetPixel(x, y)
                Dim pixel2 As Color = image2.GetPixel(x, y)

                ' Явное преобразование в Integer для предотвращения переполнения
                Dim diffR As Integer = Math.Abs(CInt(pixel1.R) - CInt(pixel2.R))
                Dim diffG As Integer = Math.Abs(CInt(pixel1.G) - CInt(pixel2.G))
                Dim diffB As Integer = Math.Abs(CInt(pixel1.B) - CInt(pixel2.B))

                If diffR > threshold OrElse
                   diffG > threshold OrElse
                   diffB > threshold Then
                    differenceCount += 1
                End If
            Next
        Next
        '
        ' Если количество отличающихся пикселей превышает порог, считаем, что произошли изменения
        Return differenceCount > image1.Width * image1.Height * 0.01 ' 1% от общего количества пикселей
    End Function

    Private _grabImage As Boolean = False
    Private Property GrabImage As Boolean
        Get
            Return _grabImage
        End Get
        Set(value As Boolean)
            _grabImage = value
            If _grabImage Then
                ReferenceFrame = CameraControl1.TakeSnapshot
            Else
                ReferenceFrame = Nothing
            End If
        End Set
    End Property

    Private Sub BarToggleSwitchItem1_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles toggleStartCamera.CheckedChanged
        GrabImage = toggleStartCamera.Checked
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMakeScreenshot.ItemClick
        SaveScreenshot()
    End Sub

    Private Sub SaveScreenshot()
        ' Проверяем, есть ли доступный кадр
        If CameraControl1 Is Nothing OrElse CameraControl1.TakeSnapshot Is Nothing Then
            MessageBox.Show("Кадр не доступен для сохранения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Получаем текущий кадр
        Dim currentFrame As Bitmap = CameraControl1.TakeSnapshot

        ' Формируем путь для сохранения
        Dim folderPath As String = "ScreenshotFolder" ' Папка для сохранения (можно задать в свойствах приложения)
        If String.IsNullOrEmpty(folderPath) Then
            folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) & "\Screenshots"
        End If

        ' Создаем папку, если она не существует
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        ' Формируем имя файла с датой и временем
        Dim fileName As String = $"Screenshot_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png"
        Dim fullPath As String = Path.Combine(folderPath, fileName)

        Try
            ' Сохраняем изображение
            currentFrame.Save(fullPath, Imaging.ImageFormat.Png)
            MessageBox.Show($"Скриншот успешно сохранен: {fullPath}", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Не удалось сохранить скриншот: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
