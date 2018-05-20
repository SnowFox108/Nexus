<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Editor.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/default/Default.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="App_Themes/default/Editor.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <!-- Code for the left Tool panel -->
    <div class="nexusCore_Editor_ToolPanel">
            <!-- This is the content -->
            <!-- End content -->
            <div class="sidebar_top">
            <telerik:RadPanelBar runat="server" ID="RadPanelBar1" Height="100%" ExpandMode="FullExpandedItem">
                <Items>
                    <telerik:RadPanelItem Expanded="True" Text="ASP.NET controls" AccessKey="A">
                        <Items>
                            <telerik:RadPanelItem Text="RadMenu" AccessKey="m">
                              <ItemTemplate>
  <telerik:RadTreeView ID="RadTreeView_WebSite" runat="server" EnableDragAndDrop="true">
                        <Nodes>
                            <telerik:RadTreeNode runat="server" Text="Root RadTreeNode1">
                                <Nodes>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 1">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 2">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 3">
                                    </telerik:RadTreeNode>
                                </Nodes>
                            </telerik:RadTreeNode>
                            <telerik:RadTreeNode runat="server" Text="Root RadTreeNode2">
                            </telerik:RadTreeNode>
                            <telerik:RadTreeNode runat="server" Text="Root RadTreeNode3">
                                <Nodes>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 1">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 2">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 3">
                                    </telerik:RadTreeNode>
                                </Nodes>
                            </telerik:RadTreeNode>
                            <telerik:RadTreeNode runat="server" Text="Root RadTreeNode4">
                            </telerik:RadTreeNode>
                            <telerik:RadTreeNode runat="server" Text="Root RadTreeNode5">
                                <Nodes>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 1">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 2">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 3">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 4">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 5">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 6">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 7">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 8">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 9">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 10">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 11">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 12">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 13">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 14">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 15">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 16">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 17">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 18">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 19">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 20">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 21">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 22">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 23">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 24">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 25">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 26">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 27">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 28">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 29">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 30">
                                    </telerik:RadTreeNode>
                                </Nodes>
                            </telerik:RadTreeNode>
                            <telerik:RadTreeNode runat="server" Text="Root RadTreeNode6">
                                <Nodes>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 1">
                                    </telerik:RadTreeNode>
                                    <telerik:RadTreeNode runat="server" Text="Child RadTreeNode 2">
                                    </telerik:RadTreeNode>
                                </Nodes>
                            </telerik:RadTreeNode>
                        </Nodes>
                    </telerik:RadTreeView>
                              </ItemTemplate>
                            </telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadTabStrip" AccessKey="t"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadPanelBar" AccessKey="p"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadTreeView" AccessKey="v"></telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem Text="WinForms controls" AccessKey="W">
                        <Items>
                            <telerik:RadPanelItem Text="RadMenustrip" AccessKey="u"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadTabStrip" AccessKey="a"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadToolStrip" AccessKey="o"></telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem Text="Other projects" AccessKey="O">
                        <Items>
                            <telerik:RadPanelItem Text="SiteFinity" AccessKey="F"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="Reporting" AccessKey="r"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadAjax" AccessKey="j"></telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                </Items>
            </telerik:RadPanelBar>
</div>
           
      <div class="sidebar_bot">
        <telerik:RadPanelBar runat="server" ID="RadPanelBar2" Height="100%" ExpandMode="FullExpandedItem">
                <Items>
                    <telerik:RadPanelItem Expanded="True" Text="ASP.NET controls">
                        <Items>
                            <telerik:RadPanelItem Text="RadAjax"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadCalendar"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadChart"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadComboBox"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadDock"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadEditor"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadGrid"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadInput"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadMenu"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadPanelBar"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadRotator"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadSpell"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadTabStrip"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadToolBar"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadTreeView"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadUpload"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadWindow"></telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem Text="WinForms controls">
                        <Items>
                            <telerik:RadPanelItem Text="RadMenustrip"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadTabStrip"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadToolStrip"></telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem Text="Other projects">
                        <Items>
                            <telerik:RadPanelItem Text="SiteFinity"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="Reporting"></telerik:RadPanelItem>
                            <telerik:RadPanelItem Text="RadAjax"></telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                </Items>
            </telerik:RadPanelBar>

</div>
    </div>
    <div class="nexusCore_Editor_MainPanel">
        <div class="nexusCore_Control_General">
            <div class="title">
                Title teitlet
            </div>
            <div class="window_buttons">
                <ul>
                   <li><a href="#"><img src="" /></a></li>
                   <li><a href="#">Edit</a></li>
                   <li><a href="#"><img src="" /></a></li>
                   <li><a href="#">delete</a></li>
                </ul>
            </div>
            <div class="content">
                <p>
                    Designer add content here</p>
                <p>
                    &nbsp;</p>
            </div>
        </div>
        <h4>
            162 Junior Suites (60 sq metres)</h4>
        <p>
            The Junior Suites are spacious and airy, with terraces looking out over the lush
            tropical gardens down to the sparkling lagoon. Red and rust-coloured tones tastefully
            blend with the mahogany wood panels and blinds. Each suite is equipped with king
            size beds, a dressing room and spacious bathroom with a large walk-in shower, two
            wash basins, a bath and separate toilets. Butler service is available on request.</p>
        <h4>
            4 Lagoon Suites (90 sq metres)</h4>
        <p>
            The Lagoon Suites offer wonderful views of the lagoon. Picture yourself watching
            the moon rising on the silvery sea as you relax in your bath! The suite has a spacious
            room with a huge bed, a bathroom with separate shower, toilet and whirlpool, as
            well as a large terrace with deck chairs facing the ocean and a table for breakfast
            at sunrise.</p>
        <h4>
            5 Honeymoon Suites (90 sq metres)</h4>
        <p>
            The Honeymoon Suites wrap newly weds in an exotic, colonial and voluptuous atmosphere
            which is further enhanced by the giant canopy bed, made of Brazilian rosewood. The
            large terraces are ideal for a romantic breakfast or candle light dinner.</p>
        <h4>
            1 Chinese Suite (100 sq metres)</h4>
        <p>
            This refined and richly decorated gem of a suite celebrates the Asian art-de-vivre.
            Close attention has been brought to every single detail, from the antique Chinese
            pottery to the finest quality silk decorations. Authenticity in luxury.</p>
        <h4>
            1 Maharajah Suite (240 sq metres)</h4>
        <p>
            This sumptuous suite indeed reflects the dream lifestyle of Maharajahs. Exquisitely
            crafted doors open on this magic place to reveal rich and opulent finery. Entirely
            decorated with furniture and accessories brought directly from India, the suite’s
            luxury is simply awe-inspiring. The comfortable lounge is equipped with deepsinking
            sofas and the private dining room adorned with rich furnishings.</p>
        <p>
            A large terrace opens on the beach and the tropical garden. The private rooftop
            solarium can be accessed from an internal staircase. A connecting Junior Suite is
            also available for those with a family or a couple of friends.</p>
        <p>
            A personal butler is at the guests’ disposal throughout their stay.</p>
        <h4>
            Rooms and Suites Sharing Policy</h4>
        <p>
            <strong>Junior Suites:</strong> 2 adults + 1 teenager or 2 adults + 2 children or
            2 adults + 1 baby<br />
            <strong>Lagoon Suites: </strong>2 adults + 1 teenager or 2 adults + 2 children or
            2 adults + 1 baby<br />
            <strong>Honeymoon Suites:</strong> 2 adults<br />
            <strong>Senior Suites: </strong>2 adults or 2 adults + 1 baby<br />
            <strong>Maharajah Suite: </strong>2 adults and can be connected with a Junior Suite,
            thus accommodating 6 persons</p>
        <p>
            <b>Note:</b><br />
            Baby: under 3 years old<br />
            Child: 3 to 11 years old<br />
            Teenager: 12 to 17 years old</p>
        <h4>
            Suites Facilities</h4>
        <ol>
            <li>All suites have a private and furnished balcony or terrace facing the ocean
            </li>
            <li>Butler service in all suite categories (on request in Junior Suites) </li>
            <li>Air conditioning and ceiling fan </li>
            <li>Bathroom with bath, separate shower and separate toilets </li>
            <li>Dressing </li>
            <li>Satellite television, music channels, LCD flat screen and DVD players in all suites
            </li>
            <li>International Direct Dialling facility </li>
            <li>Minibar </li>
            <li>Safe </li>
            <li>Hair dryer and magnifying mirror </li>
            <li>Complimentary tea and coffee facilities </li>
            <li>Whirlpool in all suites (except Junior Suites) </li>
            <li>220-240 volts electric sockets </li>
            <li>WIFI access (for a fee) </li>
        </ol>
    </div>
</body>
</html>
