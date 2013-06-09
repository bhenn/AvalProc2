Imports System.Data.Entity

Public Class AvaliacaoProcessoController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /AvaliacaoAvaliador
    Function Index(avalId As Integer) As ActionResult
        ViewBag.avalId = avalId
        Return PartialView()
    End Function

    Function List(avalId As Integer) As ActionResult
        Dim lista As List(Of Avaliacao_Processo)
        lista = db.AvaliacoesProcessos.Where(Function(x) x.AvaliacaoId = avalId).Include(Function(x) x.Processo).ToList()

        Return PartialView(lista)
    End Function

    '
    ' GET: /AvaliacaoAvaliador/Create
    Function Create(avalId As Integer) As ActionResult
        ViewBag.Avaliacao = db.Avaliacoes.Find(avalId)
        ViewBag.ProcessoId = New SelectList(db.Processos, "Id", "Descricao")
        Return PartialView()
    End Function

    <HttpPost()> _
    Function Create(ByVal avaliacaoProcesso As Avaliacao_Processo) As ActionResult
        If ModelState.IsValid Then
            db.AvaliacoesProcessos.Add(avaliacaoProcesso)
            db.SaveChanges()

            Return RedirectToAction("List", New With {.avalId = avaliacaoProcesso.AvaliacaoId})
        End If

        Return PartialView(avaliacaoProcesso)
    End Function

    <HttpPost>
    Function Delete(avaliacaoProcessoId As Integer) As ActionResult
        Dim avaliacaoProcesso As Avaliacao_Processo = db.AvaliacoesProcessos.Find(avaliacaoProcessoId)
        Dim avalId As Integer = avaliacaoProcesso.AvaliacaoId
        If Not IsNothing(avaliacaoProcesso) Then
            db.AvaliacoesProcessos.Remove(avaliacaoProcesso)
            db.SaveChanges()

            Return RedirectToAction("List", New With {.avalId = avalId})

        End If
        Return PartialView()
    End Function

End Class