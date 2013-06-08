Imports System.Data.Entity

Public Class AvaliacaoAvaliadorController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /AvaliacaoAvaliador
    Function Index(avalId As Integer) As ActionResult
        ViewBag.avalId = avalId
        Return PartialView()
    End Function

    Function List(avalId As Integer) As ActionResult
        Dim lista As List(Of Avaliacao_Avaliador)
        lista = db.AvaliacaoAvaliadores.Where(Function(x) x.AvaliacaoId = avalId).Include(Function(x) x.Avaliador).Include(Function(x) x.TipoAvaliador).ToList()

        Return PartialView(lista)
    End Function

    '
    ' GET: /AvaliacaoAvaliador/Create
    Function Create(avalId As Integer) As ActionResult
        ViewBag.Avaliacao = db.Avaliacoes.Find(avalId)
        ViewBag.AvaliadorId = New SelectList(db.Avaliadores, "Id", "Nome")
        ViewBag.TipoAvaliadorId = New SelectList(db.TipoAvaliadores, "Id", "Descricao")
        Return PartialView()
    End Function

    <HttpPost()> _
    Function Create(ByVal avaliacaoAvaliador As Avaliacao_Avaliador) As ActionResult
        If ModelState.IsValid Then
            db.AvaliacaoAvaliadores.Add(avaliacaoAvaliador)
            db.SaveChanges()

            Return RedirectToAction("List", New With {.avalId = avaliacaoAvaliador.AvaliacaoId})
        End If

        Return View(avaliacaoAvaliador)
    End Function

    <HttpPost>
    Function Delete(avaliacaoAvaliadorId As Integer) As ActionResult
        Dim avaliacaoAvaliador As Avaliacao_Avaliador = db.AvaliacaoAvaliadores.Find(avaliacaoAvaliadorId)
        Dim avalId As Integer = avaliacaoAvaliador.AvaliacaoId
        If Not IsNothing(avaliacaoAvaliador) Then
            db.AvaliacaoAvaliadores.Remove(avaliacaoAvaliador)
            db.SaveChanges()

            Return RedirectToAction("List", New With {.avalId = avalId})

        End If
        Return View()
    End Function

End Class