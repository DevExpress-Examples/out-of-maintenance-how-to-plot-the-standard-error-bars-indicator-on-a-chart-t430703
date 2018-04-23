Imports DevExpress.XtraCharts
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace ErrorBarsWin
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub
        Public Class Record
            Public Sub New(ByVal timePoint As Date, ByVal temperature As Integer)
                Me.TimePoint = timePoint
                Me.Temperature = temperature
            End Sub
            Public Property TimePoint() As Date
            Public Property Temperature() As Double
        End Class
        Private Function GetData() As List(Of Record)
            Return New List(Of Record)() From { _
                New Record(New Date(2016, 07, 01), 26), _
                New Record(New Date(2016, 07, 02), 24), _
                New Record(New Date(2016, 07, 03), 26), _
                New Record(New Date(2016, 07, 04), 29), _
                New Record(New Date(2016, 07, 05), 30), _
                New Record(New Date(2016, 07, 06), 33), _
                New Record(New Date(2016, 07, 07), 32), _
                New Record(New Date(2016, 07, 08), 30), _
                New Record(New Date(2016, 07, 09), 22), _
                New Record(New Date(2016, 07, 10), 27), _
                New Record(New Date(2016, 07, 11), 27), _
                New Record(New Date(2016, 07, 12), 28), _
                New Record(New Date(2016, 07, 13), 29), _
                New Record(New Date(2016, 07, 14), 31), _
                New Record(New Date(2016, 07, 15), 31), _
                New Record(New Date(2016, 07, 16), 32), _
                New Record(New Date(2016, 07, 17), 32), _
                New Record(New Date(2016, 07, 18), 34), _
                New Record(New Date(2016, 07, 19), 28), _
                New Record(New Date(2016, 07, 20), 29), _
                New Record(New Date(2016, 07, 21), 32), _
                New Record(New Date(2016, 07, 22), 34), _
                New Record(New Date(2016, 07, 23), 36), _
                New Record(New Date(2016, 07, 24), 34), _
                New Record(New Date(2016, 07, 25), 34), _
                New Record(New Date(2016, 07, 26), 32), _
                New Record(New Date(2016, 07, 27), 33), _
                New Record(New Date(2016, 07, 28), 35), _
                New Record(New Date(2016, 07, 29), 29), _
                New Record(New Date(2016, 07, 30), 29), _
                New Record(New Date(2016, 07, 31), 26) _
            }
        End Function
        Private ReadOnly Property series() As Series
            Get
                Return chartControl.Series(0)
            End Get
        End Property
        #Region "#StandardErrorBars"
        Private Sub FormOnLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            series.ArgumentDataMember = "TimePoint"
            series.ValueDataMembers.AddRange(New String() { "Temperature" })
            series.DataSource = GetData()
            Dim view As PointSeriesView = CType(chartControl.Series(0).View, PointSeriesView)
            view.Indicators.Add(New StandardErrorBars With {.Direction = ErrorBarDirection.Both, .Name = "Standard Error", .ShowInLegend = True})
        End Sub
        #End Region ' #StandardErrorBars
    End Class
End Namespace