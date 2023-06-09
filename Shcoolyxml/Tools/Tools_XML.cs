using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Schooly.Tools
{
    public class Tools_XML
    {
        internal string openFileXML(string titel)
        {
            var filePath = string.Empty;
            OpenFileDialog OpenFile = new OpenFileDialog();

            OpenFile.Filter = "XML Files|*.xml*"; //Filter for excel file  
            OpenFile.Multiselect = false;
            OpenFile.Title = titel;
            OpenFile.FilterIndex = 2;  //Don't know what it mean  
            OpenFile.RestoreDirectory = true;

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file  
                filePath = OpenFile.FileName;
            }
            return filePath;
        }
        internal string GetGresaEmployee(string filepath)
        {
            XDocument doc = XDocument.Load(filepath);
            XNamespace ns = doc.Root.Name.Namespace;
            return  (from act in doc.Descendants(ns + "ACTIVITE")
                           select 
                               GetValue<string>(act.Element(ns + "CD_ETAB"), "")
                         ).FirstOrDefault();

        }
        internal void GetEmployeesData(string filepath)
        {
            EmployeeDataContext edt = new EmployeeDataContext();
           
            // data
            var empdata = from d in edt.Emp_Datas
                          join a in edt.Emp_Acts on d.ppr_dat equals a.ppr_act
                          where a.CD_ETAB == Tools.Globals.GRESA
                          select d;
            edt.Emp_Datas.DeleteAllOnSubmit(empdata);
            // act
            edt.Emp_Acts.DeleteAllOnSubmit(edt.Emp_Acts.Where(em => em.CD_ETAB == Tools.Globals.GRESA));
            edt.SubmitChanges();
            //edt.ExecuteCommand("TRUNCATE TABLE Emp_Act");
            //edt.ExecuteCommand("TRUNCATE TABLE Emp_Data");
            //XElement xelem = XElement.Load(filepath);
            XDocument doc = XDocument.Load(filepath);

            
            XNamespace ns = doc.Root.Name.Namespace;

            Nullable<DateTime> MyNullableDate=null;

            var Activite = from act in doc.Descendants(ns + "ACTIVITE")
                               select new Emp_Act
                               {
                                   ppr_act = GetValue<string>(act.Element(ns + "PPR"), ""),
                                   CD_MODAFFE = GetValue<string>(act.Element(ns + "CD_MODAFFE"), ""),
                                   CD_FONC = GetValue<string>(act.Element(ns + "CD_FONC"), ""),
                                   CD_ETAB = GetValue<string>(act.Element(ns + "CD_ETAB"), ""),
                                   CD_CYCLE = GetValue<string>(act.Element(ns + "CD_CYCLE"), ""),
                                   ACTIV_PRINC = GetValue<string>(act.Element(ns + "ACTIV_PRINC"), ""),
                                   DT_DEB_EXERCICE = GetValue<string>( act.Element(ns + "DT_DEB_EXERCICE"), ""),
                                   DT_FIN_EXERCICE = GetValue<string>(act.Element(ns + "DT_FIN_EXERCICE"), ""),
                                   DATEAFFECT = GetValueD<DateTime?>(act.Element(ns + "DATEAFFECT"), MyNullableDate),
                                   DT_AFF_ETAB = GetValueD<DateTime?>(act.Element(ns + "DT_AFF_ETAB"), MyNullableDate),
                                   DT_AFF_PROV = GetValueD<DateTime?>(act.Element(ns + "DT_AFF_PROV"), MyNullableDate),
                                   DT_AFF_REG = GetValueD<DateTime?>(act.Element(ns + "DT_AFF_REG"), MyNullableDate),
                                   DT_AFF_POSTE = GetValueD<DateTime?>(act.Element(ns + "DT_AFF_POSTE"), MyNullableDate),

                               };




            var Data = from ad in doc.Descendants(ns + "DATAIDENTIFPERSONNEL")

                       select new Emp_Data

                       {
                           ppr_dat = GetValue<string>(ad.Element(ns + "PPR"), ""),
                           CINA = GetValue<string>(ad.Element(ns + "CINA"), ""),
                           CINN = GetValue<string>(ad.Element(ns + "CINN"), ""),
                           CD_POSITION = GetValue<string>(ad.Element(ns + "CD_POSITION"), ""),
                           CD_NATION = GetValue<string>(ad.Element(ns + "CD_NATION"), ""),
                           CD_DIPS = GetValue<string>(ad.Element(ns + "CD_DIPS"), ""),
                           CD_DIPP = GetValue<string>(ad.Element(ns + "CD_DIPP"), ""),
                           CD_DISCIP = GetValue<string>(ad.Element(ns + "CD_DISCIP"), ""),
                           CD_STATUT = GetValue<string>(ad.Element(ns + "CD_STATUT"), ""),
                           CD_GRADE = GetValue<string>(ad.Element(ns + "CD_GRADE"), ""),
                           MODAVGRA = GetValue<string>(ad.Element(ns + "MODAVGRA"), ""),
                           SIT_FAM = GetValue<string>(ad.Element(ns + "SIT_FAM"), ""),
                           NOML = GetValue<string>(ad.Element(ns + "NOML"), ""),
                           PRENOML = GetValue<string>(ad.Element(ns + "PRENOML"), ""),
                           NOMA = GetValue<string>(ad.Element(ns + "NOMA"), ""),
                           PRENOMA = GetValue<string>(ad.Element(ns + "PRENOMA"), ""),
                           JOUR_NAIS = GetValue<string>(ad.Element(ns + "JOUR_NAIS"), ""),
                           MOIS_NAIS = GetValue<string>(ad.Element(ns + "MOIS_NAIS"), ""),
                           AN_NAIS = GetValue<string>(ad.Element(ns + "AN_NAIS"), ""),
                           LIEU_NAIS = GetValue<string>(ad.Element(ns + "LIEU_NAIS"), ""),
                           GENRE = GetValue<string>(ad.Element(ns + "GENRE"), ""),
                           ADRESSE = GetValue<string>(ad.Element(ns + "ADRESSE"), ""),
                           CODE_POSTAL = GetValue<string>(ad.Element(ns + "CODE_POSTAL"), ""),
                           VILLE = GetValue<string>(ad.Element(ns + "VILLE"), ""),
                           TEL_PORTABLE = GetValue<string>(ad.Element(ns + "TEL_PORTABLE"), ""),
                           ADRESSE_ELEC = GetValue<string>(ad.Element(ns + "ADRESSE_ELEC"), ""),
                           DATE_REC = GetValueD<DateTime?>(ad.Element(ns + "DATE_REC"), MyNullableDate),
                           DT_TITUL = GetValueD<DateTime?>(ad.Element(ns + "DT_TITUL"), MyNullableDate),
                           ANC_ADM = GetValueD<DateTime?>(ad.Element(ns + "ANC_ADM"), MyNullableDate),
                           ANC_GRADE = GetValueD<DateTime?>(ad.Element(ns + "ANC_GRADE"), MyNullableDate),
                           ECHELON = GetValue<string>(ad.Element(ns + "ECHELON"), ""),
                           DT_ECHELON = GetValueD<DateTime?>(ad.Element(ns + "DT_ECHELON"), MyNullableDate),
                           ANC_ECHELON = GetValueD<DateTime?>(ad.Element(ns + "ANC_ECHELON"), MyNullableDate),
                           DATEAFFIL = GetValueD<DateTime?>(ad.Element(ns + "DATEAFFIL"), MyNullableDate),
                           AFFILIE = GetValue<string>(ad.Element(ns + "AFFILIE"), ""),
                           DATE_POSITION = GetValueD<DateTime?>(ad.Element(ns + "DATE_POSITION"), MyNullableDate),
                           CD_CADRE = GetValue<string>(ad.Element(ns + "CD_CADRE"), ""),
                           DT_DIPSCOL = GetValueD<DateTime?>(ad.Element(ns + "DT_DIPSCOL"), MyNullableDate),
                           DT_DIPPROF = GetValueD<DateTime?>(ad.Element(ns + "DT_DIPPROF"), MyNullableDate),
                           DT_SITSTAT = GetValueD<DateTime?>(ad.Element(ns + "DT_SITSTAT"), MyNullableDate),
                           DT_GRADE = GetValueD<DateTime?>(ad.Element(ns + "DT_GRADE"), MyNullableDate),
                           DATE_SITFAM = GetValueD<DateTime?>(ad.Element(ns + "DATE_SITFAM"), MyNullableDate),
                           DT_CADRE = GetValueD<DateTime?>(ad.Element(ns + "DT_CADRE"), MyNullableDate),
                           AffectationPrincipale = GetValue<string>(ad.Element(ns + "AffectationPrincipale"), ""),
                           NumAFFIL = GetValue<string>(ad.Element(ns + "NumAFFIL"), ""),
                           NumImma = GetValue<string>(ad.Element(ns + "NumImma"), ""),
                           VILLEFORM= GetValue<string>(ad.Element(ns + "VILLEFORM"), ""),




                       };

            //************************ fiil combo
            var cb_R_CADRE = from ac in doc.Descendants(ns + "R_CADRE")
                          
                           select new cadre
                           {
                               CD_CADRE = GetValue<string>(ac.Element(ns + "CD_CADRE"), ""),
                               LL_CADRE = GetValue<string>(ac.Element(ns + "LL_CADRE"), "") ,
                               LA_CADRE = GetValue<string>(ac.Element(ns + "LA_CADRE"), ""),

                           };
            var cb_R_CentreForm = from ac in doc.Descendants(ns + "R_CentreForm")

                                  select new centre_formation
                                  {
                                      NOM_ETABL = GetValue<string>(ac.Element(ns + "NOM_ETABL"), ""),

                                  };

            var cb_R_CYCLE = from ac in doc.Descendants(ns + "R_CYCLE")

                           select new cycle
                           {
                               CD_CYCLE = GetValue<string>(ac.Element(ns + "CD_CYCLE"), ""),
                               LL_CYCLE = GetValue<string>(ac.Element(ns + "LL_CYCLE"), ""),
                               LA_CYCLE = GetValue<string>(ac.Element(ns + "LA_CYCLE"), ""),

                           };

            var cb_R_DipProf = from ac in doc.Descendants(ns + "R_DipProf")

                             select new dippro
                             {
                                 CD_DIPP = GetValue<string>(ac.Element(ns + "CD_DIPP"), ""),
                                 LL_DIPP = GetValue<string>(ac.Element(ns + "LL_DIPP"), ""),
                                 LA_DIPP = GetValue<string>(ac.Element(ns + "LA_DIPP"), ""),

                             };

            var cb_R_DipSCol = from ac in doc.Descendants(ns + "R_DipSCol")

                               select new dipscol
                               {
                                   CD_DIPS = GetValue<string>(ac.Element(ns + "CD_DIPS"), ""),
                                   LL_DIPS = GetValue<string>(ac.Element(ns + "LL_DIPS"), ""),
                                   LA_DIPS = GetValue<string>(ac.Element(ns + "LA_DIPS"), ""),

                               };


            var cb_R_Discip = from ac in doc.Descendants(ns + "R_Discip")

                               select new discipline
                               {
                                   CD_Discip = GetValue<string>(ac.Element(ns + "CD_Discip"), ""),
                                   LL_DISCIP = GetValue<string>(ac.Element(ns + "LL_DISCIP"), ""),
                                   LA_DISCIP = GetValue<string>(ac.Element(ns + "LA_DISCIP"), ""),

                               };
            var cb_R_FONCT = from ac in doc.Descendants(ns + "R_FONCT")

                               select new fonction
                               {
                                   CD_Fonc = GetValue<string>(ac.Element(ns + "CD_Fonc"), ""),
                                   LL_FONC = GetValue<string>(ac.Element(ns + "LL_FONC"), ""),
                                   LA_Fonc = GetValue<string>(ac.Element(ns + "LA_Fonc"), ""),

                               };

            var cb_R_GRADE = from ac in doc.Descendants(ns + "R_GRADE")

                             select new grade
                             {
                                 CD_GRADE = GetValue<string>(ac.Element(ns + "CD_GRADE"), ""),
                                 LL_GRADE = GetValue<string>(ac.Element(ns + "LL_GRADE"), ""),
                                 LA_GRADE = GetValue<string>(ac.Element(ns + "LA_GRADE"), ""),

                             };

            var cb_R_MOD_ACCES_GRADE = from ac in doc.Descendants(ns + "R_MOD_ACCES_GRADE")

                            select new mode_accsses_grad
                            {
                                MODAVGRA = GetValue<string>(ac.Element(ns + "MODAVGRA"), ""),
                                LL_DESLMODAV = GetValue<string>(ac.Element(ns + "DESLMODAV"), ""),
                             //   LA_DESLMODAV = GetValue<string>(ac.Element(ns + "DESLMODAV_ar"), ""),

                            };

            var cb_R_Position = from ac in doc.Descendants(ns + "R_Position")

                                       select new position
                                       {
                                           CD_Position = GetValue<string>(ac.Element(ns + "CD_Position"), ""),
                                           LL_POSITION = GetValue<string>(ac.Element(ns + "LL_POSITION"), ""),
                                           LA_POSITION = GetValue<string>(ac.Element(ns + "LA_POSITION"), ""),

                                       };

            var cb_R_Statut = from ac in doc.Descendants(ns + "R_Statut")

                                select new sit_statut
                                {
                                    CD_Statut = GetValue<string>(ac.Element(ns + "CD_Statut"), ""),
                                    LL_STATUT = GetValue<string>(ac.Element(ns + "LL_STATUT"), ""),
                                    LA_STATUT = GetValue<string>(ac.Element(ns + "LA_STATUT"), ""),

                                };

            var cb_R_SitFam = from ac in doc.Descendants(ns + "R_SitFam")

                              select new sitfam
                              {
                                  Sit_Fam = GetValue<string>(ac.Element(ns + "Sit_Fam"), ""),
                                  LL_SitFam = GetValue<string>(ac.Element(ns + "LL_SitFam"), ""),
                                  LA_SitFam = GetValue<string>(ac.Element(ns + "LA_SitFam"), ""),

                              };
            var cb_R_MODEAFFE = from ac in doc.Descendants(ns + "R_MODEAFFE")

                              select new mode_Affectation
                              {
                                  CD_MODAFFE = GetValue<string>(ac.Element(ns + "CD_MODAFFE"), ""),
                                  LL_MODEAFFE = GetValue<string>(ac.Element(ns + "LL_MODEAFFE"), ""),
                                  LA_MODEAFFE = GetValue<string>(ac.Element(ns + "LA_MODEAFFE"), ""),

                              };

            var cb_R_NATION = from ac in doc.Descendants(ns + "R_NATION")

                                select new nation
                                {
                                    CD_NATION = GetValue<string>(ac.Element(ns + "CD_NATION"), ""),
                                    LL_NATION = GetValue<string>(ac.Element(ns + "LL_NATION"), ""),
                                    LA_NATION = GetValue<string>(ac.Element(ns + "LA_NATION"), ""),

                                };
            //******************

           
            //****************************
            edt.ExecuteCommand("TRUNCATE TABLE cadre");
            edt.ExecuteCommand("TRUNCATE TABLE centre_formation");
            edt.ExecuteCommand("TRUNCATE TABLE cycle");
            edt.ExecuteCommand("TRUNCATE TABLE dippro");
            edt.ExecuteCommand("TRUNCATE TABLE dipscol");
            edt.ExecuteCommand("TRUNCATE TABLE discipline");
            edt.ExecuteCommand("TRUNCATE TABLE fonction");
            edt.ExecuteCommand("TRUNCATE TABLE grade");
            edt.ExecuteCommand("TRUNCATE TABLE mode_accsses_grad");
            edt.ExecuteCommand("TRUNCATE TABLE position");
            edt.ExecuteCommand("TRUNCATE TABLE sit_statut");
            edt.ExecuteCommand("TRUNCATE TABLE sitfam");
            edt.ExecuteCommand("TRUNCATE TABLE mode_Affectation");
            edt.ExecuteCommand("TRUNCATE TABLE nation");
          
            //***********************
            edt.Emp_Acts.InsertAllOnSubmit(Activite);
            edt.Emp_Datas.InsertAllOnSubmit(Data);

            //*********************
            edt.cadres.InsertAllOnSubmit(cb_R_CADRE);
            edt.centre_formations.InsertAllOnSubmit(cb_R_CentreForm);
            edt.cycles.InsertAllOnSubmit(cb_R_CYCLE);
            edt.dippros.InsertAllOnSubmit(cb_R_DipProf);
            edt.dipscols.InsertAllOnSubmit(cb_R_DipSCol);
            edt.disciplines.InsertAllOnSubmit(cb_R_Discip);
            edt.fonctions.InsertAllOnSubmit(cb_R_FONCT);
            edt.grades.InsertAllOnSubmit(cb_R_GRADE);
            edt.mode_accsses_grads.InsertAllOnSubmit(cb_R_MOD_ACCES_GRADE);
            edt.positions.InsertAllOnSubmit(cb_R_Position);
            edt.sit_statuts.InsertAllOnSubmit(cb_R_Statut);
            edt.sitfams.InsertAllOnSubmit(cb_R_SitFam);
            edt.mode_Affectations.InsertAllOnSubmit(cb_R_MODEAFFE);
            edt.nations.InsertAllOnSubmit(cb_R_NATION);

            //*************

            edt.SubmitChanges();
          //  MessageBox.Show("تم مسك بيانات أوسايز بنجاح");

        }
        private T GetValue<T>(XElement elem, T defaultValue)
        {
            if (elem == null || string.IsNullOrEmpty(elem.Value) )
            {   
                return defaultValue;
            }
            else
            {   

                return (T)Convert.ChangeType(elem.Value.Trim(), typeof(T)); ;
            }
        }

        private DateTime? GetValueD<T>(XElement elem, DateTime? defaultValue)
        {
            if (elem == null || string.IsNullOrEmpty(elem.Value))
            {
                return defaultValue;
            }
            else
            {

                return (DateTime)Convert.ChangeType(elem.Value.Trim(), typeof(DateTime)); ;
            }
        }
    }
}
