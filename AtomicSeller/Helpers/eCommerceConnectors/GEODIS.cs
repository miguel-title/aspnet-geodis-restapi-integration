using AtomicSeller.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Web;
using AtomicSeller.ViewModels;
using GEODISAPI.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Text;
using System.Security.Cryptography;

namespace AtomicSeller.Helpers.eCommerceConnectors
{
    public class GEODIS
    {
        private static String ServiceHeaderName = "X-GEODIS-Service";
        private static String Lang = "fr";
        private static String BaseUrl = "https://espace-client-rct.geodis.com/services";
        private static String Id = "atomicseller";
        private static String ApiKey = "d9670a217c484dc6aa9634f32675ab72";
        private static String ServiceListe = "api/wsclient/enregistrement-envois";

        private string SendPostHttpRequest(String url, String jsonParam, String serviceHeaderValue)
        {
            const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
            const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
            ServicePointManager.SecurityProtocol = Tls12;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Headers.Add(ServiceHeaderName, serviceHeaderValue);

            using (StreamWriter writer = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                writer.Write(jsonParam);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var result = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public String GetHash(String api_key, String id, long timestamp, String lang, String service, String json_data)
        {
            Console.WriteLine();
            String message = api_key + ";" + id + ";" + timestamp + ";" + lang + ";" + service + ";" + json_data;
            Console.WriteLine("message : " + message);
            String hash = Sha256(api_key + ";" + id + ";" + timestamp + ";" + lang + ";" + service + ";" + json_data);
            Console.WriteLine("hash : " + hash);
            return hash;
        }

        public String Sha256(String str)
        {
            var crypt = new SHA256Managed();
            var sbHash = new StringBuilder();
            byte[] tbHash = crypt.ComputeHash(Encoding.UTF8.GetBytes(str));
            foreach (byte b in tbHash)
            {
                sbHash.Append(b.ToString("x2"));
            }
            return sbHash.ToString();
        }


        public ShipmentResponse GEODIS_SendParcelData()
        {
            ShipmentResponse _shipmentResult = new ShipmentResponse();
            ResponseHeader _ResponseHeader = new ResponseHeader();
            _ResponseHeader.LanguageCode = "En";
            _ResponseHeader.RequestStatus = "Ok";
            _ResponseHeader.ReturnCode = "AS0000";
            _ResponseHeader.ReturnMessage = "";
            _shipmentResult.responseHeader = _ResponseHeader;

            //Make the Request with Initail Value
            ShipmentRequest _shipmentRequest = new ShipmentRequest();
            _shipmentRequest.impressionEtiquette = false;
            _shipmentRequest.typeImpressionEtiquette = "";
            _shipmentRequest.formatEtiquette = "";
            _shipmentRequest.suppressionSiEchecValidation = false;
            _shipmentRequest.impressionBordereau = false;
            _shipmentRequest.impressionRecapitulatif = false;
            List<Envois> _lstEnvois = new List<Envois>();
            _shipmentRequest.listEnvois = _lstEnvois;
            Envois _envois = new Envois();
            _lstEnvois.Add(_envois);
            _envois.noRecepisse = "";
            _envois.noSuivi = "";
            _envois.horsSite = false;
            _envois.codeSa = "";
            _envois.codeClient = "";
            _envois.codeProduit = "";
            _envois.reference1 = "";
            _envois.reference2 = "";
            expediteur _expediteur = new expediteur();
            _envois.expediteur = _expediteur;
            _expediteur.nom = "";
            _expediteur.adresse1 = "";
            _expediteur.adresse2 = "";
            _expediteur.codePostal = "";
            _expediteur.ville = "";
            _expediteur.codePays = "";
            _expediteur.nomContact = "";
            _expediteur.email = "";
            _expediteur.telFixe = "";
            _expediteur.indTelMobile = "";
            _expediteur.telMobile = "";
            _expediteur.codePorte = "";
            _expediteur.codeTiers = "";
            _expediteur.noEntrepositaireAgree = "";
            _envois.dateDepartEnlevement = "";
            _envois.periodePreferenceEnlevement = "";
            _envois.instructionEnlevement = "";
            destinataire _destinataire = new destinataire();
            _envois.destinataire = _destinataire;
            _destinataire.nom = "";
            _destinataire.adresse1 = "";
            _destinataire.adresse2 = "";
            _destinataire.codePostal = "";
            _destinataire.ville = "";
            _destinataire.codePays = "";
            _destinataire.nomContact = "";
            _destinataire.email = "";
            _destinataire.telFixe = "";
            _destinataire.indTelMobile = "";
            _destinataire.telMobile = "";
            _destinataire.codePorte = "";
            _destinataire.codeTiers = "";
            _destinataire.noEntrepositaireAgree = "";
            List<Umgs> _lstUmgs = new List<Umgs>();
            _envois.listUmgs = _lstUmgs;
            Umgs _umgs = new Umgs();
            _lstUmgs.Add(_umgs);
            _umgs.palette = false;
            _umgs.paletteConsignee = false;
            _umgs.quantite = 0;
            _umgs.poids = 0;
            _umgs.volume = 0;
            _umgs.longueurUnitaire = 0;
            _umgs.largeurUnitaire = 0;
            _umgs.hauteurUnitaire = 0;
            _umgs.referenceColis = "";
            _envois.poidsTotal = 0;
            _envois.volumeTotal = 0;
            _envois.longueurTotale = 0;
            _envois.largeurTotale = 0;
            _envois.hauteurTotale = 0;
            uniteTaxation _uniteTax = new uniteTaxation();
            _envois.uniteTaxation = _uniteTax;
            _uniteTax.quantite = 0;
            _uniteTax.codeUnite = "";
            _envois.animauxPlumes = false;
            _envois.optionLivraison = "";
            _envois.codeSaBureauRestant = "";
            _envois.idPointRelais = "";
            _envois.dateLivraison = "";
            _envois.instructionLivraison = "";
            _envois.natureMarchandise = "";
            valeurDeclaree _valeurDeclaree = new valeurDeclaree();
            _envois.valeurDeclaree = _valeurDeclaree;
            _valeurDeclaree.quantite = 0;
            _valeurDeclaree.codeUnite = "";
            contreRemboursement _contreRemboursement = new contreRemboursement();
            _envois.contreRemboursement = _contreRemboursement;
            _contreRemboursement.quantite = 0;
            _contreRemboursement.codeUnite = "";
            _envois.codeIncotermConditionLivraison = "";
            _envois.sadSwap = false;
            _envois.sadLivEtage = false;
            _envois.sadMiseLieuUtil = false;
            _envois.sadDepotage = false;
            _envois.etage = 0;
            _envois.emailNotificationDestinataire = "";
            _envois.smsNotificationDestinataire = "";
            _envois.emailNotificationExpediteur = "";
            _envois.emailConfirmationEnlevement = "";
            _envois.emailPriseEnChargeEnlevement = "";
            _envois.poidsQteLimiteeMD = 0;
            _envois.dangerEnvQteLimiteeMD = false;
            _envois.nbColisQteExcepteeMD = 0;
            _envois.dangerEnvQteExcepteeMD = false;
            List<MatieresDangereuses> _lstmatieresdanger = new List<MatieresDangereuses>();
            MatieresDangereuses _matierdanger = new MatieresDangereuses();
            _lstmatieresdanger.Add(_matierdanger);
            _envois.listMatieresDangereuses = _lstmatieresdanger;
            _matierdanger.noONU = "";
            _matierdanger.groupeEmballage = "";
            _matierdanger.classeADR = "";
            _matierdanger.codeTypeEmballage = "";
            _matierdanger.nbEmballages = 0;
            _matierdanger.nomTechnique = "";
            _matierdanger.codeQuantite = "";
            _matierdanger.poidsVolume = 0;
            _matierdanger.dangerEnv = false;
            _envois.nosUmsAEtiqueter = "";
            List<VinsSpiritueux> _lstvinsspir = new List<VinsSpiritueux>();
            VinsSpiritueux _vinspir = new VinsSpiritueux();
            _lstvinsspir.Add(_vinspir);
            _envois.listVinsSpiritueux = _lstvinsspir;
            _vinspir.regimeFiscal = "";
            _vinspir.nbCols = 0;
            _vinspir.contenance = 0;
            _vinspir.volumeEnDroits = 0;
            _vinspir.noTitreMvtRefAdmin = "";
            _vinspir.dureeTransport = 0;
            //

            string jsonParam = string.Empty;
            jsonParam = JsonConvert.SerializeObject(_shipmentRequest, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }).ToString();

            //Make the Header Value
            long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds() * 1000;
            String hash = GetHash(ApiKey, Id, timestamp, Lang, ServiceListe, jsonParam);

            String service_header_value = Id + ";" + timestamp + ";" + Lang + ";" + hash;
            //

            string strShipmentResult = string.Empty;
            string Shipment_API_URL = BaseUrl + "/" + ServiceListe;
            try
            {
                strShipmentResult = new GEODIS().SendPostHttpRequest(Shipment_API_URL, jsonParam, service_header_value);
                ShipmentResponseData shipmentData = JsonConvert.DeserializeObject<ShipmentResponseData>(strShipmentResult);

                _shipmentResult.responseData = shipmentData;
            }
            catch (Exception ex)
            {
                if (ex is WebException && ((WebException)ex).Status == WebExceptionStatus.ProtocolError)
                {
                    WebResponse errResp = ((WebException)ex).Response;
                    using (Stream respStream = errResp.GetResponseStream())
                    {
                        // read the error response
                        var pageContent = new StreamReader(respStream).ReadToEnd();
                    }
                }

                _ResponseHeader.LanguageCode = "En";
                _ResponseHeader.RequestStatus = "Error";
                _ResponseHeader.ReturnCode = "WZ0"; ;
                _ResponseHeader.ReturnMessage = ex.Message;
                _shipmentResult.responseHeader = _ResponseHeader;
            }

            return _shipmentResult;
        }


        public List<string> GEODIS_GetShipmentLabel()
        {
            List<string> lstLabelResult = new List<string>();
            //ShipmentResponse _shipmentResult = new ShipmentResponse();
            //ResponseHeader _ResponseHeader = new ResponseHeader();
            //_ResponseHeader.LanguageCode = "En";
            //_ResponseHeader.RequestStatus = "Ok";
            //_ResponseHeader.ReturnCode = "AS0000";
            //_ResponseHeader.ReturnMessage = "";
            //_shipmentResult.responseHeader = _ResponseHeader;

            //ShipmentRequest _shipmentRequest = new ShipmentRequest();
            //_shipmentRequest.shipperId = CUSTOMERID + " " + CONTACTID;
            //_shipmentRequest.shipmentDate = "2021-12-04";
            //_shipmentRequest.references = new List<string>();
            //_shipmentRequest.references.Add("test references");
            //address _deliveryAddress = new address();
            //address _alternativeShipperAddress = new address();
            //_shipmentRequest.addresses = new addresses();
            //_shipmentRequest.addresses.delivery = _deliveryAddress;
            //_shipmentRequest.addresses.alternativeShipper = _alternativeShipperAddress;
            //_deliveryAddress.name1 = "Name or Company Name";
            //_deliveryAddress.name2 = "Complementary address";
            //_deliveryAddress.name3 = "Complementary address";
            //_deliveryAddress.street1 = "Main address";
            //_deliveryAddress.country = "FR";
            //_deliveryAddress.zipCode = "60000";
            //_deliveryAddress.city = "Compiegne";
            //_deliveryAddress.contact = "contact name";
            //_deliveryAddress.email = "email@gls-fance.fr";
            //_deliveryAddress.phone = "0351120000";
            //_deliveryAddress.mobile = "0616840012";

            //_alternativeShipperAddress.name1 = "Name or Company Name";
            //_alternativeShipperAddress.name2 = "Complementary address";
            //_alternativeShipperAddress.name3 = "Complementary address";
            //_alternativeShipperAddress.street1 = "Main address";
            //_alternativeShipperAddress.country = "FR";
            //_alternativeShipperAddress.zipCode = "21200";
            //_alternativeShipperAddress.city = "Beaune";

            //parcel _parcel = new parcel();
            //_shipmentRequest.parcels = new List<parcel>();
            //_shipmentRequest.parcels.Add(_parcel);
            //_parcel.weight = (float)2.5;
            //_parcel.references = new List<string>();
            //_parcel.references.Add("parcel specific reference");
            //_parcel.comment = "test Comment";

            //string jsonParam = string.Empty;
            //jsonParam = JsonConvert.SerializeObject(_shipmentRequest, new JsonSerializerSettings
            //{
            //    NullValueHandling = NullValueHandling.Ignore
            //}).ToString();

            //string strShipmentResult = string.Empty;
            //string Shipment_API_URL = API_BASE_URL + "/shipments";
            //try
            //{
            //    strShipmentResult = new GEODIS().SendPostHttpRequest(Shipment_API_URL, jsonParam);
            //    ShipmentResponseData shipmentData = JsonConvert.DeserializeObject<ShipmentResponseData>(strShipmentResult);

            //    _shipmentResult.responseData = shipmentData;

            //    lstLabelResult = shipmentData.labels;
            //}
            //catch (Exception ex)
            //{
            //    _ResponseHeader.LanguageCode = "En";
            //    _ResponseHeader.RequestStatus = "Error";
            //    _ResponseHeader.ReturnCode = "WZ0"; ;
            //    _ResponseHeader.ReturnMessage = ex.Message;
            //    _shipmentResult.responseHeader = _ResponseHeader;
            //}

            return lstLabelResult;
        }


        public List<string> GEODIS_GetTrackingNumber()
        {
            List<string> lstTrackingNumder = new List<string>();
            //ShipmentResponse _shipmentResult = new ShipmentResponse();
            //ResponseHeader _ResponseHeader = new ResponseHeader();
            //_ResponseHeader.LanguageCode = "En";
            //_ResponseHeader.RequestStatus = "Ok";
            //_ResponseHeader.ReturnCode = "AS0000";
            //_ResponseHeader.ReturnMessage = "";
            //_shipmentResult.responseHeader = _ResponseHeader;

            //ShipmentRequest _shipmentRequest = new ShipmentRequest();
            //_shipmentRequest.shipperId = CUSTOMERID + " " + CONTACTID;
            //_shipmentRequest.shipmentDate = "2021-12-04";
            //_shipmentRequest.references = new List<string>();
            //_shipmentRequest.references.Add("test references");
            //address _deliveryAddress = new address();
            //address _alternativeShipperAddress = new address();
            //_shipmentRequest.addresses = new addresses();
            //_shipmentRequest.addresses.delivery = _deliveryAddress;
            //_shipmentRequest.addresses.alternativeShipper = _alternativeShipperAddress;
            //_deliveryAddress.name1 = "Name or Company Name";
            //_deliveryAddress.name2 = "Complementary address";
            //_deliveryAddress.name3 = "Complementary address";
            //_deliveryAddress.street1 = "Main address";
            //_deliveryAddress.country = "FR";
            //_deliveryAddress.zipCode = "60000";
            //_deliveryAddress.city = "Compiegne";
            //_deliveryAddress.contact = "contact name";
            //_deliveryAddress.email = "email@gls-fance.fr";
            //_deliveryAddress.phone = "0351120000";
            //_deliveryAddress.mobile = "0616840012";

            //_alternativeShipperAddress.name1 = "Name or Company Name";
            //_alternativeShipperAddress.name2 = "Complementary address";
            //_alternativeShipperAddress.name3 = "Complementary address";
            //_alternativeShipperAddress.street1 = "Main address";
            //_alternativeShipperAddress.country = "FR";
            //_alternativeShipperAddress.zipCode = "21200";
            //_alternativeShipperAddress.city = "Beaune";

            //parcel _parcel = new parcel();
            //_shipmentRequest.parcels = new List<parcel>();
            //_shipmentRequest.parcels.Add(_parcel);
            //_parcel.weight = (float)2.5;
            //_parcel.references = new List<string>();
            //_parcel.references.Add("parcel specific reference");
            //_parcel.comment = "test Comment";

            //string jsonParam = string.Empty;
            //jsonParam = JsonConvert.SerializeObject(_shipmentRequest, new JsonSerializerSettings
            //{
            //    NullValueHandling = NullValueHandling.Ignore
            //}).ToString();

            //string strShipmentResult = string.Empty;
            //string Shipment_API_URL = API_BASE_URL + "/shipments";
            //try
            //{
            //    strShipmentResult = new GEODIS().SendPostHttpRequest(Shipment_API_URL, jsonParam);
            //    ShipmentResponseData shipmentData = JsonConvert.DeserializeObject<ShipmentResponseData>(strShipmentResult);

            //    _shipmentResult.responseData = shipmentData;

            //    foreach (parcelInfo parcelinfo in shipmentData.parcels)
            //    {
            //        lstTrackingNumder.Add(parcelinfo.trackId);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _ResponseHeader.LanguageCode = "En";
            //    _ResponseHeader.RequestStatus = "Error";
            //    _ResponseHeader.ReturnCode = "WZ0"; ;
            //    _ResponseHeader.ReturnMessage = ex.Message;
            //    _shipmentResult.responseHeader = _ResponseHeader;
            //}

            return lstTrackingNumder;
        }
    }
}