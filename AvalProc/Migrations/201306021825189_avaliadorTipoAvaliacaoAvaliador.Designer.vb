' <auto-generated />
Imports System.Data.Entity.Migrations
Imports System.Data.Entity.Migrations.Infrastructure
Imports System.Resources

Namespace Migrations
    Public NotInheritable Partial Class avaliadorTipoAvaliacaoAvaliador
        Implements IMigrationMetadata
    
        Private ReadOnly Resources As New ResourceManager(GetType(avaliadorTipoAvaliacaoAvaliador))
        
        Private ReadOnly Property IMigrationMetadata_Id() As String Implements IMigrationMetadata.Id
            Get
                Return "201306021825189_avaliadorTipoAvaliacaoAvaliador"
            End Get
        End Property
        
        Private ReadOnly Property IMigrationMetadata_Source() As String Implements IMigrationMetadata.Source
            Get
                Return Nothing
            End Get
        End Property
        
        Private ReadOnly Property IMigrationMetadata_Target() As String Implements IMigrationMetadata.Target
            Get
                Return Resources.GetString("Target")
            End Get
        End Property
    End Class
End Namespace
