using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GEODISAPI.Models
{
    //common class
    public class ResponseHeader
    {
        public string RequestStatus { get; set; }

        public string ReturnCode { get; set; }

        public string ReturnMessage { get; set; }

        public string LanguageCode { get; set; }
    }


    //Shipment Class
    public class ShipmentRequest
    {
        public bool impressionEtiquette { get; set; }
        public string typeImpressionEtiquette { get; set; }
        public string formatEtiquette { get; set; }
        public bool validationEnvoi { get; set; }
        public bool suppressionSiEchecValidation { get; set; }
        public bool impressionBordereau { get; set; }
        public bool impressionRecapitulatif { get; set; }
        public List<Envois> listEnvois { get; set; }
    }

    public class Envois
    {
        public string noRecepisse { get; set; }
        public string noSuivi { get; set; }
        public bool horsSite { get; set; }
        public string codeSa { get; set; }
        public string codeClient { get; set; }
        public string codeProduit { get; set; }
        public string reference1 { get; set; }
        public string reference2 { get; set; }
        public expediteur expediteur { get; set; }
        public string dateDepartEnlevement { get; set; }
        public string periodePreferenceEnlevement { get; set; }
        public string instructionEnlevement { get; set; }
        public destinataire destinataire { get; set; }
        public List<Umgs> listUmgs { get; set; }
        public double poidsTotal { get; set; }
        public double volumeTotal { get; set; }
        public double longueurTotale { get; set; }
        public double largeurTotale { get; set; }
        public double hauteurTotale { get; set; }
        public uniteTaxation uniteTaxation { get; set; }
        public bool animauxPlumes { get; set; }
        public string optionLivraison { get; set; }
        public string codeSaBureauRestant { get; set; }
        public string idPointRelais { get; set; }
        public string dateLivraison { get; set; }
        public string instructionLivraison { get; set; }
        public string natureMarchandise { get; set; }
        public valeurDeclaree valeurDeclaree { get; set; }
        public contreRemboursement contreRemboursement { get; set; }
        public string codeIncotermConditionLivraison { get; set; }
        public bool sadSwap { get; set; }
        public bool sadLivEtage { get; set; }
        public bool sadMiseLieuUtil { get; set; }
        public bool sadDepotage { get; set; }
        public int etage { get; set; }
        public string emailNotificationDestinataire { get; set; }
        public string smsNotificationDestinataire { get; set; }
        public string emailNotificationExpediteur { get; set; }
        public string emailConfirmationEnlevement { get; set; }
        public string emailPriseEnChargeEnlevement { get; set; }
        public double poidsQteLimiteeMD { get; set; }
        public bool dangerEnvQteLimiteeMD { get; set; }
        public int nbColisQteExcepteeMD { get; set; }
        public bool dangerEnvQteExcepteeMD { get; set; }
        public List<MatieresDangereuses> listMatieresDangereuses { get; set; }
        public List<VinsSpiritueux> listVinsSpiritueux { get; set; }
        public string nosUmsAEtiqueter { get; set; }
        public informationDouane informationDouane { get; set; }
    }

    public class expediteur
    {
        public string nom { get; set; }
        public string adresse1 { get; set; }
        public string adresse2 { get; set; }
        public string codePostal { get; set; }
        public string ville { get; set; }
        public string codePays { get; set; }
        public string email { get; set; }
        public string telFixe { get; set; }
        public string indTelMobile { get; set; }
        public string telMobile { get; set; }
        public string nomContact { get; set; }
        public string codePorte { get; set; }
        public string codeTiers { get; set; }
        public string noEntrepositaireAgree { get; set; }
        //public bool particulier { get; set; }
    }

    public class destinataire
    {
        public string nom { get; set; }
        public string adresse1 { get; set; }
        public string adresse2 { get; set; }
        public string codePostal { get; set; }
        public string ville { get; set; }
        public string codePays { get; set; }
        public string email { get; set; }
        public string telFixe { get; set; }
        public string indTelMobile { get; set; }
        public string telMobile { get; set; }
        public string nomContact { get; set; }
        public string codePorte { get; set; }
        public string codeTiers { get; set; }
        public string noEntrepositaireAgree { get; set; }
        public bool particulier { get; set; }
    }

    public class Umgs
    {
        public bool palette { get; set; }
        public bool paletteConsignee { get; set; }
        public int quantite { get; set; }
        public double poids { get; set; }
        public double volume { get; set; }
        public int longueurUnitaire { get; set; }
        public int largeurUnitaire { get; set; }
        public int hauteurUnitaire { get; set; }
        public string referenceColis { get; set; }
    }

    public class uniteTaxation
    {
        public double quantite { get; set; }
        public string codeUnite { get; set; }
    }

    public class valeurDeclaree
    {
        public double quantite { get; set; }
        public string codeUnite { get; set; }
    }

    public class contreRemboursement
    {
        public double quantite { get; set; }
        public string codeUnite { get; set; }
    }

    public class MatieresDangereuses
    {
        public string noONU { get; set; }
        public string groupeEmballage { get; set; }
        public string classeADR { get; set; }
        public string codeTypeEmballage { get; set; }
        public int nbEmballages { get; set; }
        public string nomTechnique { get; set; }
        public string codeQuantite { get; set; }
        public double poidsVolume { get; set; }
        public bool dangerEnv { get; set; }
    }

    public class VinsSpiritueux
    {
        public string regimeFiscal { get; set; }
        public int nbCols { get; set; }
        public double contenance { get; set; }
        public double volumeEnDroits { get; set; }
        public string noTitreMvtRefAdmin { get; set; }
        public double dureeTransport { get; set; }
    }

    public class informationDouane
    {
        public double poidsNetTotal { get; set; }
        public string eoriExpediteur { get; set; }
        public string eoriDestinataire { get; set; }
        public string emailExpediteurDouane { get; set; }
        public string indTelExpediteurDouane { get; set; }
        public string telExpediteurDouane { get; set; }
        public bool mandatRepresentation { get; set; }
        public List<Factures> listFactures { get; set; }
    }

    public class Factures
    {
        public string noFacture { get; set; }
        public montantFacture montantFacture { get; set; }
        public string dateFacture { get; set; }
    }

    public class montantFacture
    {
        public double quantite { get; set; }
        public string codeUnite { get; set; }
    }

    //response data

    public class ShipmentResponse
    {
        public ResponseHeader responseHeader { get; set; }
        public ShipmentResponseData responseData { get; set; }
    }
    public class ShipmentResponseData
    {
        public contenu contenu { get; set; }
        public bool ok{ get; set; }
        public string codeErreur { get; set; }
        public string texteErreur { get; set; }
    }

    public class contenu
    {
        public msgErreur msgErreur { get; set; }
        public int nbEnvoisATraiter { get; set; }
        public int nbEnvoisEnregistres { get; set; }
        public int nbEnvoisValides { get; set; }
        public int nbEnvoisEtiquetes { get; set; }
        public int nbEnvoisSupprimes { get; set; }
        public int nbAnomaliesSuppression { get; set; }
        public int nbAnomaliesEtiquette { get; set; }
        public int nbAnomaliesBordereau { get; set; }
        public int nbAnomaliesRecapitulatif { get; set; }
        public docEtiquette docEtiquette { get; set; }
        public docBordereau docBordereau { get; set; }
        public docRecapitulatif docRecapitulatif { get; set; }
        public msgErreurEtiquette msgErreurEtiquette { get; set; }
        public msgErreurBordereau msgErreurBordereau { get; set; }
        public msgErreurRecapitulatif msgErreurRecapitulatif { get; set; }
        public List<RetoursEnvois> listRetoursEnvois { get; set; }
    }

    public class msgErreur
    {
        public string code { get; set; }
        public string texte { get; set; }
    }

    public class docEtiquette
    {
        public string nom { get; set; }
        public string type { get; set; }
        public string contenu { get; set; }
    }

    public class docBordereau
    {
        public string nom { get; set; }
        public string type { get; set; }
        public string contenu { get; set; }
    }

    public class docRecapitulatif
    {
        public string nom { get; set; }
        public string type { get; set; }
        public string contenu { get; set; }
    }

    public class msgErreurEtiquette
    {
        public string code { get; set; }
        public string texte { get; set; }
    }

    public class msgErreurBordereau
    {
        public string code { get; set; }
        public string texte { get; set; }
    }

    public class msgErreurRecapitulatif
    {
        public string code { get; set; }
        public string texte { get; set; }
    }

    public class RetoursEnvois 
    {
        public int index { get; set; }
        public bool horsSite { get; set; }
        public string codeSa { get; set; }
        public string codeClient { get; set; }
        public string codeProduit { get; set; }
        public string reference1 { get; set; }
        public string reference2 { get; set; }
        public string dateDepartEnlevement { get; set; }
        public destinataire destinataire { get; set; }
        public string noRecepisse { get; set; }
        public string noSuivi { get; set; }
        public string urlSuiviDestinataire { get; set; }
        public docEtiquette docEtiquette { get; set; }
        public docBordereau docBordereau { get; set; }
        public docRecapitulatif docRecapitulatif { get; set; }
        public msgErreurEnregistrement msgErreurEnregistrement { get; set; }
        public msgErreurValidation msgErreurValidation { get; set; }
        public msgErreurSuppression msgErreurSuppression { get; set; }
        public msgErreurEtiquette msgErreurEtiquette { get; set; }
        public msgErreurBordereau msgErreurBordereau { get; set; }
        public msgErreurRecapitulatif msgErreurRecapitulatif { get; set; }
    }

    public class msgErreurEnregistrement
    {
        public string code { get; set; }
        public string texte { get; set; }
    }

    public class msgErreurValidation
    {
        public string code { get; set; }
        public string texte { get; set; }
    }

    public class msgErreurSuppression
    {
        public string code { get; set; }
        public string texte { get; set; }
    }
}