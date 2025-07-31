Imports PassportVision.Library.Sdk.General
Imports PassportVision.Library.Sdk.Pictures

Public Class PictureSourceType
    Implements IPictureSourceType

    Public ReadOnly Property Id As String Implements IEntity.Id
        Get
            Return "1"
        End Get
    End Property

    Public ReadOnly Property Caption As String Implements IEntity.Caption
        Get
            Return "PictureSourceType"
        End Get
    End Property

    Public ReadOnly Property Description As String Implements IEntity.Description
        Get
            Return "Description"
        End Get
    End Property

    Public Function GetEntityReference() As IEntity Implements IEntity.GetEntityReference
        Return Me
    End Function
End Class
