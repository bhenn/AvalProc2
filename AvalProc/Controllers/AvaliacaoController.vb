Imports System.Data.Entity

Public Class AvaliacaoController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /Avaliacao/

    Function Index() As ActionResult
        Dim avaliacoes = db.Avaliacoes.Include(Function(a) a.Empresa)
        Return View(avaliacoes.ToList())
    End Function

    '
    ' GET: /Avaliacao/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim avaliacao As Avaliacao = db.Avaliacoes.Find(id)
        If IsNothing(avaliacao) Then
            Return HttpNotFound()
        End If
        Return View(avaliacao)
    End Function

    '
    ' GET: /Avaliacao/Create

    Function Create() As ActionResult
        ViewBag.EmpresaId = New SelectList(db.Empresas, "Id", "Nome")
        Return View()
    End Function

    '
    ' POST: /Avaliacao/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal avaliacao As Avaliacao) As ActionResult
        If ModelState.IsValid Then
            db.Avaliacoes.Add(avaliacao)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        ViewBag.EmpresaId = New SelectList(db.Empresas, "Id", "Nome", avaliacao.EmpresaId)
        Return View(avaliacao)
    End Function

    '
    ' GET: /Avaliacao/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim avaliacao As Avaliacao = db.Avaliacoes.Find(id)
        If IsNothing(avaliacao) Then
            Return HttpNotFound()
        End If
        ViewBag.EmpresaId = New SelectList(db.Empresas, "Id", "Nome", avaliacao.EmpresaId)
        ViewBag.AvaliacaoAvaliadores = db.AvaliacaoAvaliadores.Include(Function(x) x.Avaliador).Include(Function(x) x.TipoAvaliador).ToList()
        ViewBag.Avaliacao = avaliacao
        Return View()
    End Function

    '
    ' POST: /Avaliacao/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal avaliacao As Avaliacao) As ActionResult
        If ModelState.IsValid Then
            db.Entry(avaliacao).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        ViewBag.EmpresaId = New SelectList(db.Empresas, "Id", "Nome", avaliacao.EmpresaId)
        Return View(avaliacao)
    End Function

    '
    ' GET: /Avaliacao/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim avaliacao As Avaliacao = db.Avaliacoes.Find(id)
        If IsNothing(avaliacao) Then
            Return HttpNotFound()
        End If
        Return View(avaliacao)
    End Function

    '
    ' POST: /Avaliacao/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim avaliacao As Avaliacao = db.Avaliacoes.Find(id)
        db.Avaliacoes.Remove(avaliacao)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Function ListAvaliador(avalId As Integer) As PartialViewResult
        Dim list As List(Of Avaliacao_Avaliador)
        'list = db.AvaliacaoAvaliadores.Where(Function(x) x.AvaliacaoId = avalId).ToList()
        list = db.AvaliacaoAvaliadores.Where(Function(x) x.AvaliacaoId = avalId).Include(Function(x) x.Avaliador).Include(Function(x) x.TipoAvaliador).ToList()

        Return PartialView(list)
    End Function


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub


End Class