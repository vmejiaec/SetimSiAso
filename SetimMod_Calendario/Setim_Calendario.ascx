<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Setim_Calendario.ascx.cs" Inherits="SetimMod_Calendario.Setim_Calendario" %>

<%@ Register TagPrefix="dnn" 
    Namespace="DotNetNuke.Web.Client.ClientResourceManagement" 
    Assembly="DotNetNuke.Web.Client" %>


<%--
    <dnn:DnnCssInclude runat="server" 
    FilePath="~/DesktopModules/<moduleName>/css/custom.css" />
--%>

<dnn:DnnCssInclude runat="server" 
    FilePath="~/Resources/Shared/fullcalendar-2.3.2/fullcalendar.css" />

<dnn:DnnCssInclude runat="server" 
    FilePath="~/Resources/Shared/fullcalendar-2.3.2/fullcalendar.print.css" />

<script src="/Resources/Shared/fullcalendar-2.3.2/lib/moment.min.js" 
    type="text/javascript"></script>

<script src="/Resources/Shared/fullcalendar-2.3.2/fullcalendar.min.js" 
    type="text/javascript"></script>



<script type="text/javascript">

    $(document).ready(function () {

        $('#calendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,basicWeek,basicDay'
            },
            defaultDate: '2015-07-10',
            editable: true,
            eventLimit: true, // allow "more" link when too many events
            events: [
				{
				    title: 'Reunión Semanal',
				    start: '2015-07-01'
				},
				{
				    title: 'Evento de dos días',
				    start: '2015-07-07',
				    end: '2015-07-10'
				},
				{
				    id: 999,
				    title: 'Encuentro con socios',
				    start: '2015-07-09T16:00:00'
				},
				{
				    id: 999,
				    title: 'Junta general de Socios',
				    start: '2015-07-31T16:00:00'
				},
				{
				    title: 'Ciclo de conferencias',
				    start: '2015-07-20',
				    end: '2015-07-21'
				},
				{
				    title: 'Inicio',
				    start: '2015-07-21T10:30:00',
				    end: '2015-07-21T12:30:00'
				},
				{
				    title: 'Almuerzo',
				    start: '2015-07-21T12:00:00'
				},
				{
				    title: 'Fin de la conferencia',
				    start: '2015-07-21T14:30:00'
				},
				{
				    title: 'Happy Hour',
				    start: '2015-07-21T17:30:00'
				},
				{
				    title: 'Cena',
				    start: '2015-07-21T20:00:00'
				},
				{
				    title: 'Cumpleaños del Socio',
				    start: '2015-07-15T07:00:00'
				},
				{
				    title: 'Encuentro deportivo',
				    url: 'http://google.com/',
				    start: '2015-07-28'
				}
            ]
        });

    });

</script>

<h1>Calendario</h1>
	<div id='calendar' style="max-width: 900px; margin: 0 auto;" ></div>