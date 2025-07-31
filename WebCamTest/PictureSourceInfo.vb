Imports PassportVision.Library.Sdk.General
Imports PassportVision.Library.Sdk.Pictures
Imports System.Collections.ObjectModel

Public Class PictureSourceInfo
    Implements IPictureSourceInfo

    Public Property ThisCreationDateTime As Date

    Public Sub New()
        ThisCreationDateTime = Now
    End Sub


    Public ReadOnly Property SourceType As IPictureSourceType Implements IPictureSourceInfo.SourceType
        Get
            Return New PictureSourceType()
        End Get
    End Property

    Public ReadOnly Property Protocol As String Implements IPictureSourceInfo.Protocol
        Get
            Return "DevExpressCameraControl"
        End Get
    End Property

    Public ReadOnly Property Uri As String Implements IPictureSourceInfo.Uri
        Get
            Return String.Empty
        End Get
    End Property

    Public ReadOnly Property CreationDateTime As String Implements IPictureSourceInfo.CreationDateTime
        Get
            Return ThisCreationDateTime.ToString("yyyy-MM-dd-HH-mm-ss")
        End Get
    End Property

    Public ReadOnly Property Properties As ReadOnlyCollection(Of IPictureSourceProperty) Implements IPictureSourceInfo.Properties
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property Id As String Implements IEntity.Id
        Get
            Return "0"
        End Get
    End Property

    Public ReadOnly Property Caption As String Implements IEntity.Caption
        Get
            Return "Захват изображения с камеры"
        End Get
    End Property

    Public ReadOnly Property Description As String Implements IEntity.Description
        Get
            Return "Description"
        End Get
    End Property

    Public Function CloneWithNewCreationDateTime(creationDateTime As Date) As IPictureSourceInfo Implements IPictureSourceInfo.CloneWithNewCreationDateTime
        Dim newInfo As PictureSourceInfo = Me.MemberwiseClone
        newInfo.ThisCreationDateTime = creationDateTime
        Return newInfo
    End Function

    Public Function CloneWithAdditionalProperies(additionalProperies As ReadOnlyCollection(Of IPictureSourceProperty)) As IPictureSourceInfo Implements IPictureSourceInfo.CloneWithAdditionalProperies
        Dim newInfo As PictureSourceInfo = Me.MemberwiseClone
        Return newInfo
    End Function

    Public Function GetEntityReference() As IEntity Implements IEntity.GetEntityReference
        Throw New NotImplementedException()
    End Function
End Class
