Imports System.Data.Entity

Public Class AvaliacaoAvaliadorController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /AvaliacaoAvaliador
    Function Index() As ActionResult
        Return PartialView()
    End Function

    Function List(avalId As Integer) As PartialViewResult
        Dim lista As List(Of Avaliacao_Avaliador)
        lista = db.AvaliacaoAvaliadores.Where(Function(x) x.AvaliacaoId = avalId).Include(Function(x) x.Avaliador).Include(Function(x) x.TipoAvaliador).ToList()

        Return PartialView(lista)
    End Function

    '
    ' GET: /Avaliacao/Create

    Function Create(avalId As Integer) As ActionResult
        ViewBag.Avaliacao = db.Avaliacoes.Find(avalId)
        ViewBag.AvaliadorId = New SelectList(db.Avaliadores, "Id", "Nome")
        ViewBag.TipoAvaliadorId = New SelectList(db.TipoAvaliadores, "Id", "Descricao")
        Return View()
    End Function

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal avaliacaoAvaliador As Avaliacao_Avaliador) As ActionResult
        If ModelState.IsValid Then
            db.AvaliacaoAvaliadores.Add(avaliacaoAvaliador)
            db.SaveChanges()

            Dim avaliacao As Avaliacao = db.Avaliacoes.Find(avaliacaoAvaliador.AvaliacaoId)
            ViewBag.EmpresaId = New SelectList(db.Empresas, "Id", "Nome", avaliacao.EmpresaId)
            ViewBag.AvaliacaoAvaliadores = db.AvaliacaoAvaliadores.Include(Function(x) x.Avaliador).Include(Function(x) x.TipoAvaliador).ToList()

            Return RedirectToAction("Edit", "Avaliacao", New With {.id = avaliacaoAvaliador.AvaliacaoId})
        End If

        'ViewBag.EmpresaId = New SelectList(db.Empresas, "Id", "Nome", avaliacao.EmpresaId)
        Return View(avaliacaoAvaliador)
    End Function

    <HttpPost>
    Function Delete(avalId As Integer, avaliacaoAvaliadorId As Integer) As ActionResult
        Dim avaliacaoAvaliador As Avaliacao_Avaliador = db.AvaliacaoAvaliadores.Find(avaliacaoAvaliadorId)
        If Not IsNothing(avaliacaoAvaliador) Then
            db.AvaliacaoAvaliadores.Remove(avaliacaoAvaliador)
            db.SaveChanges()

            Return RedirectToAction("ListAvaliador", "Avaliacao", New With {.avalId = avalId})

        End If
        Return View()
    End Function

End Class