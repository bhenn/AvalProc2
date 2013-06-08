Imports System.Data.Entity

<Authorize>
Public Class AvaliacaoController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /Avaliacao/

    Function Index() As ActionResult
        Return View()
    End Function

    Function List() As ActionResult
        Return PartialView(db.Avaliacoes.Include(Function(a) a.Empresa).ToList())
    End Function

    Function Create() As ActionResult
        ViewBag.EmpresaId = New SelectList(db.Empresas, "Id", "Nome")
        Return PartialView()
    End Function


    <HttpPost()> _
    Function Create(ByVal avaliacao As Avaliacao) As ActionResult
        If ModelState.IsValid Then
            db.Avaliacoes.Add(avaliacao)
            db.SaveChanges()
            Return RedirectToAction("List")
        End If

        ViewBag.EmpresaId = New SelectList(db.Empresas, "Id", "Nome", avaliacao.EmpresaId)
        Return View(avaliacao)
    End Function


    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim avaliacao As Avaliacao = db.Avaliacoes.Include(Function(e) e.Empresa).Where(Function(a) a.Id = id).FirstOrDefault()
        If IsNothing(avaliacao) Then
            Return HttpNotFound()
        End If
        ViewBag.EmpresaId = New SelectList(db.Empresas, "Id", "Nome", avaliacao.EmpresaId)
        ViewBag.AvaliacaoAvaliadores = db.AvaliacaoAvaliadores.Include(Function(x) x.Avaliador).Include(Function(x) x.TipoAvaliador).ToList()
        'ViewBag.Avaliacao = avaliacao
        Return View(avaliacao)
    End Function


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



    <HttpPost()>
    Function Delete(ByVal id As Integer) As RedirectToRouteResult
        Dim avaliacao As Avaliacao = db.Avaliacoes.Find(id)
        db.Avaliacoes.Remove(avaliacao)
        db.SaveChanges()
        Return RedirectToAction("List")
    End Function




    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub


End Class