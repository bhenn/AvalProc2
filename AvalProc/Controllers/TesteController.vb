Public Class TesteController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /Teste

    Function Index() As ActionResult

        Return View(db.Testes.ToList())
    End Function

    <HttpPost()> _
<ActionName("Delete")> _
<ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim teste As Teste = db.Testes.Find(id)
        db.Testes.Remove(teste)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

End Class