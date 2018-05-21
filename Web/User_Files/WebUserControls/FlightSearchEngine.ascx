<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FlightSearchEngine.ascx.cs" Inherits="Sites_Fly2Mauritius_Controls_FlightSearchEngine" %>
<style>
    .searchEngine {
        background-image: url('/Sites/Fly2Mauritius/images/main-image.jpg');
        height: 380px;
    }
     @media (max-width:767px) {
         .searchEngine {
            height: 750px;            
         }
     }
</style>
<div class="full-width searchEngine">
    <div class="span8" style="padding-top: 45px; color: white;">
        <div class="span12 no_space">
            <section class="welly form_align">
                <div class="acc-form" style="max-width: 760px; background: rgba(0, 0, 0, 0.7); border: 1px;">
                    <div class="row-fluid">
                        <div class="span12">
                            <h2>Flights</h2>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span3">
                            <div>
                                <label>
                                    Departure Airport:
                                </label>
                                <div>
                                    <asp:DropDownList ID="ddlFromAirport" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="LHR">London Heathrow</asp:ListItem>
                                        <asp:ListItem Value="LGW">London Gatwick</asp:ListItem>
                                        <asp:ListItem Value="MAN">Manchester</asp:ListItem>
                                        <asp:ListItem Value="BHX">Birmingham</asp:ListItem>
                                        <asp:ListItem Value="GLA">Glasgow</asp:ListItem>
                                        <asp:ListItem Value="EDI">Edinburgh</asp:ListItem>
                                        <asp:ListItem Value="MRU">Mauritius</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="text-error" ID="RequiredFieldValidator2"
                                        runat="server"
                                        ErrorMessage="Please select a from airport" ValidationGroup="FlightSearchEngine" ControlToValidate="ddlFromAirport" InitialValue=""></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="span3">
                            <div>
                                <label>
                                    Return Airport:
                                </label>
                                <div>
                                    <asp:DropDownList ID="ddlToAirport" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="MRU">Mauritius</asp:ListItem>
                                        <asp:ListItem Value="LHR">London Heathrow</asp:ListItem>
                                        <asp:ListItem Value="LGW">London Gatwick</asp:ListItem>
                                        <asp:ListItem Value="MAN">Manchester</asp:ListItem>
                                        <asp:ListItem Value="BHX">Birmingham</asp:ListItem>
                                        <asp:ListItem Value="GLA">Glasgow</asp:ListItem>
                                        <asp:ListItem Value="EDI">Edinburgh</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="text-error" ID="RequiredFieldValidator3"
                                        runat="server"
                                        ErrorMessage="Please select a to airport" ValidationGroup="FlightSearchEngine" ControlToValidate="ddlToAirport" InitialValue=""></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="span3">
                            <div>
                                <label>
                                    Departure Date:
                                </label>
                                <div>
                                    <telerik:RadDatePicker ID="RadDatePicker_DepartureDate" runat="server" CssClass="input-small">
                                    </telerik:RadDatePicker>
                                    <div>
                                        <asp:CustomValidator Display="Dynamic" CssClass="text-error" ID="CustomValidator_DepartureDate"
                                            runat="server" ErrorMessage="" ControlToValidate="ddlFromAirport" ValidationGroup="FlightSearchEngine"
                                            OnServerValidate="CustomValidator_DepartureDate_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="span3">
                            <div>
                                <label>
                                    Return Date:
                                </label>
                                <div>
                                    <telerik:RadDatePicker ID="RadDatePicker_ReturnDate" runat="server" CssClass="input-small">
                                    </telerik:RadDatePicker>
                                    <div>
                                        <asp:CustomValidator Display="Dynamic" CssClass="text-error" ID="CustomValidator_ReturnDate"
                                            runat="server" ErrorMessage="" ControlToValidate="ddlFromAirport" ValidationGroup="FlightSearchEngine"
                                            OnServerValidate="CustomValidator_ReturnDate_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span3">
                            <div>
                                <label>
                                    Prefered Class:
                                </label>
                                <div>
                                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1">Economy</asp:ListItem>
                                        <asp:ListItem Value="2">Business</asp:ListItem>
                                        <asp:ListItem Value="3">First</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">Any</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="span3">
                            <div>
                                <label>
                                    Prefered Airlines:
                                </label>
                                <div>
                                    <asp:DropDownList ID="ddlAirlines" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="--Please Select --">All Airlines</asp:ListItem>
                                        <asp:ListItem Value="EI">Aer Lingus P.L.C.</asp:ListItem>
                                        <asp:ListItem Value="SU">Aeroflot Russian Airlines</asp:ListItem>
                                        <asp:ListItem Value="AR">Aerolineas Argentinas</asp:ListItem>
                                        <asp:ListItem Value="5D">Aerolitoral</asp:ListItem>
                                        <asp:ListItem Value="VW">Aeromar Airlines</asp:ListItem>
                                        <asp:ListItem Value="AM">Aeromexico</asp:ListItem>
                                        <asp:ListItem Value="XU">African Express Airways</asp:ListItem>
                                        <asp:ListItem Value="8U">Afriqiyah</asp:ListItem>
                                        <asp:ListItem Value="DP">Air 2000 Ltd</asp:ListItem>
                                        <asp:ListItem Value="8U">Air Afrique</asp:ListItem>
                                        <asp:ListItem Value="4L">Air Astana</asp:ListItem>
                                        <asp:ListItem Value="BT">Air Baltic</asp:ListItem>
                                        <asp:ListItem Value="AB">Air Berlin</asp:ListItem>
                                        <asp:ListItem Value="JA">Air Bosnia</asp:ListItem>
                                        <asp:ListItem Value="BP">Air Botswana</asp:ListItem>
                                        <asp:ListItem Value="AC">Air Canada</asp:ListItem>
                                        <asp:ListItem Value="CA">Air China</asp:ListItem>
                                        <asp:ListItem Value="4F">Air City</asp:ListItem>
                                        <asp:ListItem Value="PE">Air Europe</asp:ListItem>
                                        <asp:ListItem Value="AF">Air France</asp:ListItem>
                                        <asp:ListItem Value="GN">Air Gabon</asp:ListItem>
                                        <asp:ListItem Value="GL">Air Greenland</asp:ListItem>
                                        <asp:ListItem Value="NY">Air Iceland</asp:ListItem>
                                        <asp:ListItem Value="AI">Air India</asp:ListItem>
                                        <asp:ListItem Value="JM">Air Jamaica</asp:ListItem>
                                        <asp:ListItem Value="NQ">Air Japan</asp:ListItem>
                                        <asp:ListItem Value="TT">Air Lithuania</asp:ListItem>
                                        <asp:ListItem Value="FU">Air Littoral</asp:ListItem>
                                        <asp:ListItem Value="LK">Air Luxor</asp:ListItem>
                                        <asp:ListItem Value="KM">Air Malta Company</asp:ListItem>
                                        <asp:ListItem Value="MK">Air Mauritius</asp:ListItem>
                                        <asp:ListItem Value="ZV">Air Midwest</asp:ListItem>
                                        <asp:ListItem Value="SW">Air Namibia</asp:ListItem>
                                        <asp:ListItem Value="NZ">Air New Zealand</asp:ListItem>
                                        <asp:ListItem Value="EL">Air Nippon Co.</asp:ListItem>
                                        <asp:ListItem Value="PX">Air Niugini</asp:ListItem>
                                        <asp:ListItem Value="FJ">Air Pacific Limited</asp:ListItem>
                                        <asp:ListItem Value="HM">Air Seychelles</asp:ListItem>
                                        <asp:ListItem Value="GM">Air Slovakia</asp:ListItem>
                                        <asp:ListItem Value="TN">Air Tahiti Nui</asp:ListItem>
                                        <asp:ListItem Value="TC">Air Tanzania</asp:ListItem>
                                        <asp:ListItem Value="6U">Air Ukraine</asp:ListItem>
                                        <asp:ListItem Value="UM">Air Zimbabwe</asp:ListItem>
                                        <asp:ListItem Value="AS">Alaska Airlines</asp:ListItem>
                                        <asp:ListItem Value="LV">Albanian Airlines</asp:ListItem>
                                        <asp:ListItem Value="AZ">Alitalia</asp:ListItem>
                                        <asp:ListItem Value="XM">Alitalia Express</asp:ListItem>
                                        <asp:ListItem Value="NH">All Nippon Airways</asp:ListItem>
                                        <asp:ListItem Value="AQ">Aloha Airlines</asp:ListItem>
                                        <asp:ListItem Value="HP">America West Airlines</asp:ListItem>
                                        <asp:ListItem Value="AA">American Airlines</asp:ListItem>
                                        <asp:ListItem Value="MQ">American Eagle Airlines</asp:ListItem>
                                        <asp:ListItem Value="OZ">Asiana Airlines</asp:ListItem>
                                        <asp:ListItem Value="AO">Australian Airlines</asp:ListItem>
                                        <asp:ListItem Value="OS">Austrian Airlines</asp:ListItem>
                                        <asp:ListItem Value="AV">Avianca</asp:ListItem>
                                        <asp:ListItem Value="UP">Bahamasair</asp:ListItem>
                                        <asp:ListItem Value="PG">Bangkok Airways</asp:ListItem>
                                        <asp:ListItem Value="B3">Bellview</asp:ListItem>
                                        <asp:ListItem Value="J8">Berjaya Air</asp:ListItem>
                                        <asp:ListItem Value="BG">Biman Bangladesh</asp:ListItem>
                                        <asp:ListItem Value="BD">bmi british midland</asp:ListItem>
                                        <asp:ListItem Value="WW">bmibaby</asp:ListItem>
                                        <asp:ListItem Value="BU">Braathens ASA</asp:ListItem>
                                        <asp:ListItem Value="BA">British Airways</asp:ListItem>
                                        <asp:ListItem Value="TH">British Airways Citiexpress</asp:ListItem>
                                        <asp:ListItem Value="BE">British European</asp:ListItem>
                                        <asp:ListItem Value="KJ">British Mediterranean Airways</asp:ListItem>
                                        <asp:ListItem Value="SN">Brussels Airlines</asp:ListItem>
                                        <asp:ListItem Value="FB">Bulgaria Air</asp:ListItem>
                                        <asp:ListItem Value="BW">BWIA West Indies Airways</asp:ListItem>
                                        <asp:ListItem Value="CX">Cathay Pacific Airways</asp:ListItem>
                                        <asp:ListItem Value="KX">Cayman Airways</asp:ListItem>
                                        <asp:ListItem Value="CI">China Airlines</asp:ListItem>
                                        <asp:ListItem Value="MU">China Eastern</asp:ListItem>
                                        <asp:ListItem Value="CZ">China Southern</asp:ListItem>
                                        <asp:ListItem Value="CF">City Airline</asp:ListItem>
                                        <asp:ListItem Value="WX">City Jet</asp:ListItem>
                                        <asp:ListItem Value="OH">Comair Inc.</asp:ListItem>
                                        <asp:ListItem Value="DE">Condor</asp:ListItem>
                                        <asp:ListItem Value="CO">Continental Airlines</asp:ListItem>
                                        <asp:ListItem Value="OU">Croatia Airlines</asp:ListItem>
                                        <asp:ListItem Value="CU">Cubana</asp:ListItem>
                                        <asp:ListItem Value="CY">Cyprus Airways</asp:ListItem>
                                        <asp:ListItem Value="YK">Cyprus Turkish</asp:ListItem>
                                        <asp:ListItem Value="OK">Czech Airlines</asp:ListItem>
                                        <asp:ListItem Value="DL">Delta Air Lines</asp:ListItem>
                                        <asp:ListItem Value="VB">Duo Airways</asp:ListItem>
                                        <asp:ListItem Value="MS">Egyptair</asp:ListItem>
                                        <asp:ListItem Value="LY">El Al Israel Airlines</asp:ListItem>
                                        <asp:ListItem Value="EK">Emirates Airlines</asp:ListItem>
                                        <asp:ListItem Value="OV">Estonian Air Lines</asp:ListItem>
                                        <asp:ListItem Value="ET">Ethiopian Air Lines</asp:ListItem>
                                        <asp:ListItem Value="EY">Etihad Airlines</asp:ListItem>
                                        <asp:ListItem Value="GJ">EuroFly</asp:ListItem>
                                        <asp:ListItem Value="BR">EVA Airways Corporation</asp:ListItem>
                                        <asp:ListItem Value="AY">Finnair</asp:ListItem>
                                        <asp:ListItem Value="GA">Garuda Indonesian</asp:ListItem>
                                        <asp:ListItem Value="GT">GB Airways</asp:ListItem>
                                        <asp:ListItem Value="GF">Gulf Air Company</asp:ListItem>
                                        <asp:ListItem Value="HA">Hawaiian Airlines</asp:ListItem>
                                        <asp:ListItem Value="ZU">Helios Airways</asp:ListItem>
                                        <asp:ListItem Value="DU">Hemus Air</asp:ListItem>
                                        <asp:ListItem Value="T4">Hellas Jet</asp:ListItem>
                                        <asp:ListItem Value="IB">Iberia</asp:ListItem>
                                        <asp:ListItem Value="FI">Icelandair</asp:ListItem>
                                        <asp:ListItem Value="IC">Indian Airlines</asp:ListItem>
                                        <asp:ListItem Value="2S">Island Express</asp:ListItem>
                                        <asp:ListItem Value="JL">Japan Airlines</asp:ListItem>
                                        <asp:ListItem Value="9W">Jet Airways India</asp:ListItem>
                                        <asp:ListItem Value="KQ">Kenya Airways</asp:ListItem>
                                        <asp:ListItem Value="IT">Kingfisher</asp:ListItem>
                                        <asp:ListItem Value="WA">KLM Cityhopper B V</asp:ListItem>
                                        <asp:ListItem Value="XT">KLM Exel</asp:ListItem>
                                        <asp:ListItem Value="KL">KLM Royal Dutch Airlines</asp:ListItem>
                                        <asp:ListItem Value="UK">KLM UK</asp:ListItem>
                                        <asp:ListItem Value="KE">Korean Air</asp:ListItem>
                                        <asp:ListItem Value="KU">Kuwait Airways</asp:ListItem>
                                        <asp:ListItem Value="LA">Lan Chile S.A.</asp:ListItem>
                                        <asp:ListItem Value="TE">Lithuanian Airlines</asp:ListItem>
                                        <asp:ListItem Value="LO">LOT Polish Airlines</asp:ListItem>
                                        <asp:ListItem Value="LT">LTU International Airways</asp:ListItem>
                                        <asp:ListItem Value="LH">Lufthansa</asp:ListItem>
                                        <asp:ListItem Value="LG">Luxair</asp:ListItem>
                                        <asp:ListItem Value="DM">Maersk Air A/S</asp:ListItem>
                                        <asp:ListItem Value="MH">Malaysia Airline</asp:ListItem>
                                        <asp:ListItem Value="MA">Malev Hungarian Airlines</asp:ListItem>
                                        <asp:ListItem Value="W5">Mahan Air</asp:ListItem>
                                        <asp:ListItem Value="ME">MEA</asp:ListItem>
                                        <asp:ListItem Value="IG">Meridiana</asp:ListItem>
                                        <asp:ListItem Value="YX">Midwest Express Airlines</asp:ListItem>
                                        <asp:ListItem Value="ZB">Monarch Airlines</asp:ListItem>
                                        <asp:ListItem Value="MP">Martinair</asp:ListItem>
                                        <asp:ListItem Value="8M">Myanmar Airways</asp:ListItem>
                                        <asp:ListItem Value="YJ">National Airlines - South Africa</asp:ListItem>
                                        <asp:ListItem Value="CE">Nationwide Airlines</asp:ListItem>
                                        <asp:ListItem Value="NW">Northwest Airlines Inc</asp:ListItem>
                                        <asp:ListItem Value="O8">Oasis Hong Kong</asp:ListItem>
                                        <asp:ListItem Value="OA">Olympic Airways</asp:ListItem>
                                        <asp:ListItem Value="WY">Oman Air</asp:ListItem>
                                        <asp:ListItem Value="PK">Pakistan International Airlines</asp:ListItem>
                                        <asp:ListItem Value="PR">Philippine Airlines</asp:ListItem>
                                        <asp:ListItem Value="9R">Phuket Airlines</asp:ListItem>
                                        <asp:ListItem Value="PH">Polynesian Airlines</asp:ListItem>
                                        <asp:ListItem Value="NI">Portugalia</asp:ListItem>
                                        <asp:ListItem Value="QF">Qantas Airways</asp:ListItem>
                                        <asp:ListItem Value="QR">Qatar Airways</asp:ListItem>
                                        <asp:ListItem Value="AT">Royal Air Maroc</asp:ListItem>
                                        <asp:ListItem Value="BI">Royal Brunei Air</asp:ListItem>
                                        <asp:ListItem Value="RJ">Royal Jordanian</asp:ListItem>
                                        <asp:ListItem Value="RA">Royal Nepal Airlines</asp:ListItem>
                                        <asp:ListItem Value="SK">SAS Scandinavian Airlines</asp:ListItem>
                                        <asp:ListItem Value="SP">SATA Air Acores</asp:ListItem>
                                        <asp:ListItem Value="SV">Saudi Arabian Airlines</asp:ListItem>
                                        <asp:ListItem Value="MI">SilkAir</asp:ListItem>
                                        <asp:ListItem Value="SQ">Singapore Airlines</asp:ListItem>
                                        <asp:ListItem Value="SA">South African Airways</asp:ListItem>
                                        <asp:ListItem Value="UL">SriLankan Airlines</asp:ListItem>
                                        <asp:ListItem Value="NB">Sterling Air</asp:ListItem>
                                        <asp:ListItem Value="LX">SWISS</asp:ListItem>
                                        <asp:ListItem Value="RB">Syrian Arab Airlines</asp:ListItem>
                                        <asp:ListItem Value="JJ">TAM</asp:ListItem>
                                        <asp:ListItem Value="TP">TAP Air Portugal</asp:ListItem>
                                        <asp:ListItem Value="RO">Tarom</asp:ListItem>
                                        <asp:ListItem Value="TG">Thai Airways Intl</asp:ListItem>
                                        <asp:ListItem Value="UN">Transaero Airlines</asp:ListItem>
                                        <asp:ListItem Value="TU">Tunis Air</asp:ListItem>
                                        <asp:ListItem Value="TK">Turkish Airlines</asp:ListItem>
                                        <asp:ListItem Value="VO">Tyrolean Airways</asp:ListItem>
                                        <asp:ListItem Value="PS">Ukraine International Airline</asp:ListItem>
                                        <asp:ListItem Value="UA">United Airlines Inc</asp:ListItem>
                                        <asp:ListItem Value="U6">Ural Airlines</asp:ListItem>
                                        <asp:ListItem Value="US">US Airways</asp:ListItem>
                                        <asp:ListItem Value="HY">Uzbekistan Airways</asp:ListItem>
                                        <asp:ListItem Value="RG">Varig</asp:ListItem>
                                        <asp:ListItem Value="VN">Vietnam Airlines</asp:ListItem>
                                        <asp:ListItem Value="VS">Virgin Atlantic Airways</asp:ListItem>
                                        <asp:ListItem Value="VS">Virgin Nigeria Airways</asp:ListItem>
                                        <asp:ListItem Value="VG">VLM Airlines</asp:ListItem>
                                        <asp:ListItem Value="VA">Volare Airlines</asp:ListItem>
                                        <asp:ListItem Value="IY">Yemenia Yemen Airways</asp:ListItem>
                                        <asp:ListItem Value="JU">Yugoslav Airlines -JAT</asp:ListItem>
                                        <asp:ListItem Value="Q3">Zambian Airways</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="span2">
                            <div>
                                <label>
                                    Adutls:
                                </label>
                                <div>
                                    <asp:DropDownList ID="ddlAdutls" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="span2">
                            <div>
                                <label>
                                    Childrens:
                                </label>
                                <div>
                                    <asp:DropDownList ID="ddlChildren" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="span2">
                            <div>
                                <label>
                                    Infants:
                                </label>
                                <div>
                                    <asp:DropDownList ID="ddlInfants" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div>
                                    <div class="pull-right">
                                        <asp:Button ID="btn_Submit" CssClass="btn btn-primary" runat="server" Text="Submit"
                                            ValidationGroup="FlightSearchEngine"
                                            OnClick="btn_Submit_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
    <div class="span2"></div>

</div>

