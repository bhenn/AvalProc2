Imports System.Data.Entity
Public Class AvaliacaoProcessoPaController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto


    '
    ' GET: /AvaliacaoProcessoPa

    Function Index() As ActionResult
        Return View()
    End Function

    Function Edit(avaliacaoProcessoId As Integer, avaliacaoId As Integer) As ActionResult

        ViewBag.avaliacaoId = avaliacaoId
        Return PartialView(db.AvaliacoesProcessosPas.Include(Function(x) x.Pa).Where(Function(x) x.AvaliacaoProcessoId = avaliacaoProcessoId).ToList())
    End Function

    <HttpPost>
    Function Edit(colecao As FormCollection) As ActionResult

        If ModelState.IsValid Then
            Dim Id As String() = colecao.GetValues("$VB$Local_item.Id")
            Dim Pontuacao As String() = colecao.GetValues("$VB$Local_item.Pontuacao")
            Dim avaliacaoId As Integer = Request("avaliacaoId")
            Dim avaliacaoProcessoId As Integer = CInt(Request("avaliacaoProcessoId"))

            For i = 0 To Id.Length - 1

                Dim AvaliacaoProcessoPa As Avaliacao_Processo_Pa = db.AvaliacoesProcessosPas.Find(CInt(Id(i)))
                AvaliacaoProcessoPa.Pontuacao = Pontuacao(i)

                db.Entry(AvaliacaoProcessoPa).State = EntityState.Modified
            Next
            db.SaveChanges()

            aplicaAvaliacao(avaliacaoProcessoId)

            Return RedirectToAction("List", "AvaliacaoProcesso", New With {.avalId = avaliacaoId})
        End If

        Return RedirectToAction("List", "AvaliacaoProcesso")
    End Function

    Sub aplicaAvaliacao(avaliacaoProcessoId As Integer)
        Dim listaAvaliacaoProcessoPa As List(Of Avaliacao_Processo_Pa)
        listaAvaliacaoProcessoPa = db.AvaliacoesProcessosPas.Include(Function(x) x.Pa).Where(Function(x) x.AvaliacaoProcessoId = avaliacaoProcessoId).ToList()

        Dim nivelCapacidade As String = "0"
        Dim retorno As String = ""

        Dim pa1 As String = listaAvaliacaoProcessoPa.Where(Function(x) x.Pa.Nome.Contains("1.1")).FirstOrDefault.Pontuacao
        Dim pa2 As String = listaAvaliacaoProcessoPa.Where(Function(x) x.Pa.Nome.Contains("2.1")).FirstOrDefault.Pontuacao
        Dim pa22 As String = listaAvaliacaoProcessoPa.Where(Function(x) x.Pa.Nome.Contains("2.2")).FirstOrDefault.Pontuacao
        Dim pa3 As String = listaAvaliacaoProcessoPa.Where(Function(x) x.Pa.Nome.Contains("3.1")).FirstOrDefault.Pontuacao
        Dim pa32 As String = listaAvaliacaoProcessoPa.Where(Function(x) x.Pa.Nome.Contains("3.2")).FirstOrDefault.Pontuacao
        Dim pa4 As String = listaAvaliacaoProcessoPa.Where(Function(x) x.Pa.Nome.Contains("4.1")).FirstOrDefault.Pontuacao
        Dim pa42 As String = listaAvaliacaoProcessoPa.Where(Function(x) x.Pa.Nome.Contains("4.2")).FirstOrDefault.Pontuacao
        Dim pa5 As String = listaAvaliacaoProcessoPa.Where(Function(x) x.Pa.Nome.Contains("5.1")).FirstOrDefault.Pontuacao
        Dim pa52 As String = listaAvaliacaoProcessoPa.Where(Function(x) x.Pa.Nome.Contains("5.2")).FirstOrDefault.Pontuacao

        If pa1 = "F" Then
            nivelCapacidade = "1"
            If (pa2 = "F" And pa22 = "F") Then
                nivelCapacidade = "2"
                If (pa3 = "F" And pa32 = "F") Then
                    nivelCapacidade = "3"
                    If (pa4 = "F" And pa42 = "F") Then
                        nivelCapacidade = "4"
                        If (pa5 = "F" Or pa5 = "L") And (pa52 = "F" Or pa52 = "L") Then
                            nivelCapacidade = "5"
                        End If
                    Else
                        If (pa4 = "F" Or pa4 = "L") And (pa42 = "F" Or pa42 = "L") Then
                            nivelCapacidade = "4"
                        End If
                    End If
                Else
                    If (pa3 = "F" Or pa3 = "L") And (pa32 = "F" Or pa32 = "L") Then
                        nivelCapacidade = "3"
                    End If
                End If
            Else
                If (pa2 = "F" Or pa2 = "L") And (pa22 = "F" Or pa22 = "L") Then
                    nivelCapacidade = "2"
                End If
            End If
        ElseIf pa1 = "L" Then
            nivelCapacidade = "1"
        End If

        Select Case nivelCapacidade
            Case "0"
                retorno = "0 - Incompleto"
            Case "1"
                retorno = "1 - Executado"
            Case "2"
                retorno = "2 - Gerenciado"
            Case "3"
                retorno = "3 - Definido"
            Case "4"
                retorno = "4 - Previsível"
            Case "5"
                retorno = "5 - Em otimização"
        End Select


        Dim AvaliacaoProcesso As Avaliacao_Processo = db.AvaliacoesProcessos.Find(avaliacaoProcessoId)
        AvaliacaoProcesso.NivelCapacidade = retorno

        db.Entry(AvaliacaoProcesso).State = EntityState.Modified
        db.SaveChanges()

    End Sub

End Class