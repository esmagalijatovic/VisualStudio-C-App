using NasaMK1;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp
{
    public class Baza
    {
        OracleConnection konekcija;
        OracleDataReader reader;
        public List<Zaposleni> zaposlenici = new List<Zaposleni>();
        public List<HitniPacijent> pacijenti = new List<HitniPacijent>();
        public List<Ordinacija> ordinacije = new List<Ordinacija>();
        public List<Aparat> aparati = new List<Aparat>();
        public List<Karton> kartoni = new List<Karton>();
        public List<Doktor> doktori = new List<Doktor>();
        public List<Pregled> pregledi = new List<Pregled>();

        DataSet dataSet;
        OracleDataAdapter dataAdapter;

        public OracleDataAdapter DataAdapter { get => dataAdapter; set => dataAdapter = value; }
        public DataSet DataSet { get => dataSet; set => dataSet = value; }
        public List<Zaposleni> Zaposlenici { get => zaposlenici; set => zaposlenici = value; }
        public List<Doktor> Doktori { get => doktori; set => doktori = value; }
        public List<Karton> Kartoni { get => kartoni; set => kartoni = value; }
        public List<Aparat> Aparati { get => aparati; set => aparati = value; }
        public List<Ordinacija> Ordinacije { get => ordinacije; set => ordinacije = value; }
        public List<HitniPacijent> Pacijenti { get => pacijenti; set => pacijenti = value; }

        public Baza() { }
        public void ucitajZaposlenikeIDoktore()
        {
            zaposlenici = new List<Zaposleni>();
            OracleCommand command = new OracleCommand();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string tip;
                    Zaposleni z = new Zaposleni();
                    z.ID = reader.GetInt32(0);
                    z.imeIprezime = reader.GetString(1);
                    z.plata = reader.GetInt32(3);
                    tip = reader.GetString(4);
                    z.username = reader.GetString(5);
                    z.Md5pass = reader.GetString(6);
                    z.datumRodjenja = Convert.ToDateTime(reader["DatumRodjenja"]);
                    if (tip == "Doktor")
                    {
                        z.tipPosla = Posao.Doktor;
                        Doktor d = new Doktor(z.imeIprezime, z.datumRodjenja, z.plata, z.username, z.Md5pass, z.ID);
                        d.brojPacijenataDan = reader.GetInt32(7);
                        d.brojPacijenataUkupno = reader.GetInt32(8);
                        d.Bonus = reader.GetDecimal(9);
                        d.dostupan = reader.GetBoolean(10);
                        d.vracaSe = Convert.ToDateTime(reader["vracaSe"]);
                        doktori.Add(d);
                    }
                    else
                    {
                        if (tip == "Medicinski tehnicar") z.tipPosla = Posao.MedTehnicar;
                        else if (tip == "Cistaci") z.tipPosla = Posao.Cistaci;
                        else if (tip == "Tehnicko osoblje") z.tipPosla = Posao.TehAdmin;
                        else if (tip == "Uprava") z.tipPosla = Posao.Uprava;
                        zaposlenici.Add(z);
                    }
                }
            }
        }

        public void ucitajPacijente()
        {
            pacijenti = new List<HitniPacijent>();
            OracleCommand command = new OracleCommand();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HitniPacijent p = new HitniPacijent();
                    string spol;
                    p.ID = reader.GetInt32(0);
                    p.imeIprezime = reader.GetString(1);
                    p.datumRodjenja = Convert.ToDateTime(reader["DatumRodjenja"]);
                    p.datumPrijema = Convert.ToDateTime(reader["datumPrijema"]);
                    p.jmbg = reader.GetInt64(3);
                    spol = reader.GetString(4);
                    if (reader.GetInt32(5) == 0) p.uBraku = false; else p.uBraku=true;
                    p.adresa = reader.GetString(6);
                    p.prvaPomoc = reader.GetString(8);
                    p.razlogSmrti = reader.GetString(9);
                    p.vrijemeSmrti = Convert.ToDateTime(reader["VrijemeSmrti"]);
                    p.terminObdukcije = Convert.ToDateTime(reader["TerminObdukcije"]);
                    pacijenti.Add(p);

                }

            }
        }

        public void ucitajKartone()
        {
            Karton k = new Karton();
            kartoni = new List<Karton>();
            OracleCommand command = new OracleCommand();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.pacijentID = reader.GetInt32(1);
                    k.prethodneAlergije = reader.GetString(2);
                    k.prethodneBolesti = reader.GetString(3);
                    k.alergije = reader.GetString(4);
                    k.bolesti = reader.GetString(5);
                    k.username = reader.GetString(6);
                    k.Pass = reader.GetString(7);
                    if (reader.GetInt32(8) == 0) k.otvoren = false; else k.otvoren=true ;
                    k.termin = Convert.ToDateTime(reader["Termin"]);
                    kartoni.Add(k); // FALE LISTEEEEEEeEEEEEEEEEEEEE i terapijaaaaaaaaaaa
                }
            }
        }
        
        public void ucitajOrdinacije()
        {
            Ordinacija o = new Ordinacija();
            ordinacije = new List<Ordinacija>();
            OracleCommand command = new OracleCommand();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string tip;
                    o.ID = reader.GetInt32(0);
                    tip = reader.GetString(1);
                    if (reader.GetInt32(2) == 0) o.dostupna = false; else o.dostupna = true;
                    if (reader.GetInt32(4) == 0) o.imaAparat = false; else o.dostupna = true;
                    
                    o.doktorId = reader.GetInt32(3);
                    o.aparatId = reader.GetInt32(5);
                    if (tip == "Opsta medicina") o.poljeMedicine = TipOrdinacija.OpstaMedicina;
                    else if (tip == "Hitna sluzba") o.poljeMedicine = TipOrdinacija.HitnaSluzba;
                    else if (tip == "Ortopedska") o.poljeMedicine = TipOrdinacija.Ortopedska;
                    else if (tip == "Kardioloska") o.poljeMedicine = TipOrdinacija.Kardioloska;
                    else if (tip == "Dermatoloska") o.poljeMedicine = TipOrdinacija.Dermatoloska;
                    else if (tip == "Internisticka") o.poljeMedicine = TipOrdinacija.Internisticka;
                    else if (tip == "Otorinolaringoloska") o.poljeMedicine = TipOrdinacija.Otorinolaringoloska;
                    else if (tip == "Oftalmoloska") o.poljeMedicine = TipOrdinacija.Oftamoloska;
                    else if (tip == "Laboratorijska") o.poljeMedicine = TipOrdinacija.Laboratorijska;
                    else if (tip == "Stomatoloska") o.poljeMedicine = TipOrdinacija.Stomatoloska;
                        ordinacije.Add(o);
                }
            }
        }

        public void ucitajAparate()
        {
            Aparat a = new Aparat();
            aparati = new List<Aparat>();
            OracleCommand command = new OracleCommand();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    a.ID = reader.GetInt32(0);
                    a.tip = reader.GetString(1);
                    if (reader.GetInt32(2) == 0) a.zauzet = false; else a.zauzet = true;
                    if (reader.GetInt32(3) == 0) a.uKvaru = false; else a.uKvaru = true;
                    if (reader.GetInt32(4) == 0) a.trebaGasiti = false; else a.trebaGasiti = true;
                    a.periodGasenja = Convert.ToDateTime(reader["periodGasenja"]);
                    a.proraditCe = Convert.ToDateTime(reader["proraditCe"]);
                    a.putaUKvaru = reader.GetInt32(6);
                    aparati.Add(a);
                }
            }

        }

        public void ucitajPreglede()
        {
            Pregled p = new Pregled();
            pregledi = new List<Pregled>();
            OracleCommand command = new OracleCommand();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    p.ID = reader.GetInt32(0);
                    p.opisPregleda = reader.GetString(1);
                    p.doktorID = reader.GetInt32(2);
                    p.pacijentID = reader.GetInt32(3);
                    p.ordinacijaID = reader.GetInt32(4);
                    p.hitan = reader.GetBoolean(5);
                    p.obavljen = reader.GetBoolean(6);
                    p.termin = Convert.ToDateTime(reader["termin"]);
                    pregledi.Add(p);
                }
            }
        }

        public int brisiZaposlenika(int index)
        {
            try
            {
                OracleCommand cmd = konekcija.CreateCommand();
                string sqlDelete = "delete from zaposlenici where id=:id";
                cmd.CommandText = sqlDelete;
                OracleParameter id = new OracleParameter();
                id.Value = zaposlenici[index].ID;
                id.ParameterName = "id";
                cmd.Parameters.Add(id);
                int k = cmd.ExecuteNonQuery();
                cmd.Dispose();
                zaposlenici.RemoveAt(index);
                return k;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int brisiPacijenta(int index)
        {
            try
            {
                OracleCommand cmd = konekcija.CreateCommand();
                string sqlDelete = "delete from pacijenti where id=:id";
                cmd.CommandText = sqlDelete;
                OracleParameter id = new OracleParameter();
                id.Value = pacijenti[index].ID;
                id.ParameterName = "id";
                cmd.Parameters.Add(id);
                int k = cmd.ExecuteNonQuery();
                cmd.Dispose();
                pacijenti.RemoveAt(index);
                return k;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int brisiOrdinaciju(int index)
        {
            try
            {
                OracleCommand cmd = konekcija.CreateCommand();
                string sqlDelete = "delete from ordinacije where tip=:tip";
                cmd.CommandText = sqlDelete;
                OracleParameter id = new OracleParameter();
                id.Value = ordinacije[index].ID;
                id.ParameterName = "id";
                cmd.Parameters.Add(id);
                int k = cmd.ExecuteNonQuery();
                cmd.Dispose();
                ordinacije.RemoveAt(index);
                return k;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int brisiAparat(int index)
        {
            try
            {
                OracleCommand cmd = konekcija.CreateCommand();
                string sqlDelete = "delete from aparati where id=:id";
                cmd.CommandText = sqlDelete;
                OracleParameter id = new OracleParameter();
                id.Value = aparati[index].ID;
                id.ParameterName = "id";
                cmd.Parameters.Add(id);
                int k = cmd.ExecuteNonQuery();
                cmd.Dispose();
                aparati.RemoveAt(index);
                return k;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int brisiKarton(int index)
        {
            try
            {
                OracleCommand cmd = konekcija.CreateCommand();
                string sqlDelete = "delete from kartoni where id=:id";
                cmd.CommandText = sqlDelete;
                OracleParameter id = new OracleParameter();
                id.Value = kartoni[index].ID;
                id.ParameterName = "id";
                cmd.Parameters.Add(id);
                int k = cmd.ExecuteNonQuery();
                cmd.Dispose();
                kartoni.RemoveAt(index);
                return k;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int brisiPregled(int index)
        {
            try
            {
                OracleCommand cmd = konekcija.CreateCommand();
                string sqlDelete = "delete from pregledi where id=:id";
                cmd.CommandText = sqlDelete;
                OracleParameter id = new OracleParameter();
                id.Value = pregledi[index].ID;
                id.ParameterName = "id";
                cmd.Parameters.Add(id);
                int k = cmd.ExecuteNonQuery();
                cmd.Dispose();
                pregledi.RemoveAt(index);
                return k;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int editZaposlenika(int index, Zaposleni z)
        {
            try
            {
                OracleCommand cmd = konekcija.CreateCommand();
                string sqlInsert = "update zaposlenici set imeIprezime=:k_ImePrezime, plata=:k_Plata, datumRodjenja=:k_DatumRodjenja " +
                    "tipPosla=:k_TipPosla, username=:k_Username, Md5pass=:k_MD5pass where id=:id";
                cmd.CommandText = sqlInsert;
                OracleParameter id = new OracleParameter();
                id.Value = zaposlenici[index].ID;
                id.ParameterName = "id";

                OracleParameter k_ImePrezime = new OracleParameter();
                k_ImePrezime.Value = zaposlenici[index].imeIprezime;
                k_ImePrezime.ParameterName = "k_ImePrezime";

                OracleParameter k_Plata = new OracleParameter();
                k_Plata.Value = zaposlenici[index].plata;
                k_Plata.ParameterName = "k_Plata";

                OracleParameter k_DatumRodjenja = new OracleParameter();
                k_DatumRodjenja.Value = zaposlenici[index].datumRodjenja;
                k_DatumRodjenja.ParameterName = "k_DatumRodjenja";

                OracleParameter k_TipPosla = new OracleParameter();
                k_TipPosla.Value = zaposlenici[index].tipPosla.ToString();
                k_TipPosla.ParameterName = "k_TipPosla";

                OracleParameter k_Username = new OracleParameter();
                k_Username.Value = zaposlenici[index].username;
                k_Username.ParameterName = "k_Username";

                OracleParameter k_MD5pass = new OracleParameter();
                k_MD5pass.Value = zaposlenici[index].Md5pass;
                k_MD5pass.ParameterName = "k_MD5pass";

                cmd.Parameters.Add(k_ImePrezime);
                cmd.Parameters.Add(k_MD5pass);
                cmd.Parameters.Add(k_Plata);
                cmd.Parameters.Add(k_TipPosla);
                cmd.Parameters.Add(k_Username);
                cmd.Parameters.Add(id);
                cmd.Parameters.Add(k_DatumRodjenja);
                int k = cmd.ExecuteNonQuery();
                cmd.Dispose();
                zaposlenici[index] = z;
                return k;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public int editDoktora(int index, Doktor z)
        {
            try
            {
                OracleCommand cmd = konekcija.CreateCommand();
                string sqlInsert = "update doktori set imeIprezime=:k_ImePrezime, plata=:k_Plata, datumRodjenja=:k_DatumRodjenja " +
                    "tipPosla=:k_TipPosla, username=:k_Username, Md5pass=:k_MD5pass, brojPacijenataDan =:k_brDan, brojPacijenataUkupno=:=k_brUk, bonus:=k_bonus, " +
                    "dostupan := k_dostupan, vracaSe:=k_vracaSe where id=:id";
                cmd.CommandText = sqlInsert;
                OracleParameter id = new OracleParameter();
                id.Value = doktori[index].ID;
                id.ParameterName = "id";

                OracleParameter k_ImePrezime = new OracleParameter();
                k_ImePrezime.Value = doktori[index].imeIprezime;
                k_ImePrezime.ParameterName = "k_ImePrezime";

                OracleParameter k_Plata = new OracleParameter();
                k_Plata.Value = doktori[index].plata;
                k_Plata.ParameterName = "k_Plata";

                OracleParameter k_DatumRodjenja = new OracleParameter();
                k_DatumRodjenja.Value = doktori[index].datumRodjenja;
                k_DatumRodjenja.ParameterName = "k_DatumRodjenja";

                OracleParameter k_TipPosla = new OracleParameter();
                k_TipPosla.Value = doktori[index].tipPosla.ToString();
                k_TipPosla.ParameterName = "k_TipPosla";

                OracleParameter k_Username = new OracleParameter();
                k_Username.Value = doktori[index].username;
                k_Username.ParameterName = "k_Username";

                OracleParameter k_MD5pass = new OracleParameter();
                k_MD5pass.Value = doktori[index].Md5pass;
                k_MD5pass.ParameterName = "k_MD5pass";

                OracleParameter k_brDan = new OracleParameter();
                k_brDan.Value = doktori[index].brojPacijenataDan;
                k_brDan.ParameterName = "k_brDan";

                OracleParameter k_brUk = new OracleParameter();
                k_brUk.Value = doktori[index].brojPacijenataUkupno;
                k_brUk.ParameterName = "k_brUk";

                OracleParameter k_bonus = new OracleParameter();
                k_bonus.Value = doktori[index].Bonus;
                k_bonus.ParameterName = "k_bonus";

                OracleParameter k_vracaSe = new OracleParameter();
                k_MD5pass.Value = doktori[index].vracaSe;
                k_MD5pass.ParameterName = "k_vracaSe";

                OracleParameter k_dostupan = new OracleParameter();
                k_dostupan.Value = doktori[index].dostupan;
                k_dostupan.ParameterName = "k_dostupan";

                cmd.Parameters.Add(k_ImePrezime);
                cmd.Parameters.Add(k_MD5pass);
                cmd.Parameters.Add(k_Plata);
                cmd.Parameters.Add(k_TipPosla);
                cmd.Parameters.Add(k_Username);
                cmd.Parameters.Add(id);
                cmd.Parameters.Add(k_DatumRodjenja);
                cmd.Parameters.Add(k_brDan);
                cmd.Parameters.Add(k_brUk);
                cmd.Parameters.Add(k_bonus);
                cmd.Parameters.Add(k_dostupan);
                cmd.Parameters.Add(k_vracaSe);
                int k = cmd.ExecuteNonQuery();
                cmd.Dispose();
                doktori[index] = z;
                return k;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public int editPacijenata(int index, HitniPacijent p)
        {
            try
            {
                OracleCommand cmd = konekcija.CreateCommand();
                string sqlInsert = "update pacijenti set imeIprezime=:k_ImePrezime, datumRodjenja=:k_DatumRodjenja " +
                    "jmbg=:k_jmbg, spol=:k_spol, uBraku=:k_uBraku, adresa=:k_adresa, datumPrijema:=k_datPrij, prvaPomoc:=k_pp," +
                    "razlogSmrti:=k_uzrok, vrijemeSmrti:=k_vrijeme, terminObdukcije:=k_obdukcija where id=:id";
                cmd.CommandText = sqlInsert;
                OracleParameter id = new OracleParameter();
                id.Value = pacijenti[index].ID;
                id.ParameterName = "id";

                OracleParameter k_ImePrezime = new OracleParameter();
                k_ImePrezime.Value = pacijenti[index].imeIprezime;
                k_ImePrezime.ParameterName = "k_ImePrezime";


                OracleParameter k_DatumRodjenja = new OracleParameter();
                k_DatumRodjenja.Value = pacijenti[index].datumRodjenja;
                k_DatumRodjenja.ParameterName = "k_DatumRodjenja";

                OracleParameter k_jmbg = new OracleParameter();
                k_jmbg.Value = pacijenti[index].jmbg;
                k_jmbg.ParameterName = "k_jmbg";

                OracleParameter k_spol = new OracleParameter();
                k_spol.Value = pacijenti[index].spol.ToString();
                k_spol.ParameterName = "k_spol";

                OracleParameter k_uBraku = new OracleParameter();
                k_uBraku.Value = pacijenti[index].uBraku;
                k_uBraku.ParameterName = "k_uBraku";

                OracleParameter k_adresa = new OracleParameter();
                k_adresa.Value = pacijenti[index].adresa;
                k_adresa.ParameterName = "k_adresa";

                OracleParameter k_datPrij = new OracleParameter();
                k_datPrij.Value = pacijenti[index].datumPrijema;
                k_datPrij.ParameterName = "k_datPrij";

                OracleParameter k_pp = new OracleParameter();
                k_pp.Value = pacijenti[index].prvaPomoc;
                k_pp.ParameterName = "k_pp";

                OracleParameter k_uzrok = new OracleParameter();
                k_uzrok.Value = pacijenti[index].razlogSmrti;
                k_uzrok.ParameterName = "k_uzrok";

                OracleParameter k_vrijeme = new OracleParameter();
                k_vrijeme.Value = pacijenti[index].vrijemeSmrti;
                k_vrijeme.ParameterName = "k_vrijeme";

                OracleParameter k_obdukcija = new OracleParameter();
                k_obdukcija.Value = pacijenti[index].terminObdukcije;
                k_obdukcija.ParameterName = "k_obdukcija";


                cmd.Parameters.Add(k_ImePrezime);
                cmd.Parameters.Add(k_DatumRodjenja);
                cmd.Parameters.Add(k_jmbg);
                cmd.Parameters.Add(k_spol);
                cmd.Parameters.Add(k_uBraku);
                cmd.Parameters.Add(id);
                cmd.Parameters.Add(k_adresa);
                cmd.Parameters.Add(k_datPrij);
                cmd.Parameters.Add(k_pp);
                cmd.Parameters.Add(k_uzrok);
                cmd.Parameters.Add(k_vrijeme);
                cmd.Parameters.Add(k_obdukcija);
                int k = cmd.ExecuteNonQuery();
                cmd.Dispose();
                pacijenti[index] = p;
                return k;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public int editKartona(int index, Karton k)
        {
            try
            {
                OracleCommand cmd = konekcija.CreateCommand();
                string sqlInsert = "update kartoni set pacijentID:=k_pacid, prethodneAlergije:=k_palg, prethodneBolesti:=k_pbol, alergije:=k_alergije," +
                    "bolesti:=k_bolesti, username:=k_username, Pass:=k_pass, otvoren:=k_otvoren, termin:=k_termin where id=:id";
                cmd.CommandText = sqlInsert;
                OracleParameter id = new OracleParameter();
                id.Value = kartoni[index].ID;
                id.ParameterName = "id";

                OracleParameter k_pacid = new OracleParameter();
                k_pacid.Value = kartoni[index].pacijentID;
                k_pacid.ParameterName = "k_pacid";


                OracleParameter k_palg = new OracleParameter();
                k_palg.Value = kartoni[index].prethodneAlergije;
                k_palg.ParameterName = "k_palg";

                OracleParameter k_pbol = new OracleParameter();
                k_pbol.Value = kartoni[index].prethodneBolesti;
                k_pbol.ParameterName = "k_pbol";

                OracleParameter k_alergije = new OracleParameter();
                k_alergije.Value = kartoni[index].alergije;
                k_alergije.ParameterName = "k_alergije";

                OracleParameter k_bolesti = new OracleParameter();
                k_bolesti.Value = kartoni[index].bolesti;
                k_bolesti.ParameterName = "k_bolesti";

                OracleParameter k_username = new OracleParameter();
                k_username.Value = kartoni[index].username;
                k_username.ParameterName = "k_username";

                OracleParameter k_pass = new OracleParameter();
                k_pass.Value = kartoni[index].Pass;
                k_pass.ParameterName = "k_pass";

                OracleParameter k_otvoren = new OracleParameter();
                k_otvoren.Value = kartoni[index].otvoren;
                k_otvoren.ParameterName = "k_otvoren";

                OracleParameter k_termin = new OracleParameter();
                k_termin.Value = kartoni[index].termin;
                k_termin.ParameterName = "k_termin";

                cmd.Parameters.Add(k_pacid);
                cmd.Parameters.Add(k_palg);
                cmd.Parameters.Add(k_pbol);
                cmd.Parameters.Add(k_alergije);
                cmd.Parameters.Add(k_bolesti);
                cmd.Parameters.Add(id);
                cmd.Parameters.Add(k_otvoren);
                cmd.Parameters.Add(k_termin);
                cmd.Parameters.Add(k_username);
                cmd.Parameters.Add(k_pass);
                int i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                kartoni[index] = k;
                return i;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int editOrdinacija(int index, Ordinacija o)
        {
            try
            {
                OracleCommand cmd = konekcija.CreateCommand();
                string sqlInsert = "update ordinacije set tip:=k_tip, dostupna:=k_dostupna, doktorID:=k_doktorID, imaAparat:=k_imaap," +
                    "aparatID= k_aparatID where id=:id";
                cmd.CommandText = sqlInsert;
                OracleParameter id = new OracleParameter();
                id.Value = ordinacije[index].ID;
                id.ParameterName = "id";

                OracleParameter k_tip = new OracleParameter();
                k_tip.Value = ordinacije[index].poljeMedicine.ToString();
                k_tip.ParameterName = "k_tip";


                OracleParameter k_dostupna = new OracleParameter();
                k_dostupna.Value = ordinacije[index].dostupna;
                k_dostupna.ParameterName = "k_dostupna";

                OracleParameter k_doktorID = new OracleParameter();
                k_doktorID.Value = ordinacije[index].doktorId;
                k_doktorID.ParameterName = "k_doktorID";

                OracleParameter k_imaap = new OracleParameter();
                k_imaap.Value = ordinacije[index].imaAparat;
                k_imaap.ParameterName = "k_imaap";

                OracleParameter k_aparatID = new OracleParameter();
                k_aparatID.Value = ordinacije[index].aparatId;
                k_aparatID.ParameterName = "k_aparatID";

                cmd.Parameters.Add(k_aparatID);
                cmd.Parameters.Add(k_doktorID);
                cmd.Parameters.Add(k_dostupna);
                cmd.Parameters.Add(k_imaap);
                cmd.Parameters.Add(k_tip);
                cmd.Parameters.Add(id);
                int i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                ordinacije[index] = o;
                return i;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public int editAparata(int index, Aparat a)
        {
            try
            {
                OracleCommand cmd = konekcija.CreateCommand();
                string sqlInsert = "update aparati set tip=:k_tip, zauzet=:k_zauzet, uKvaru=:k_uKvaru, trebaGasiti=:k_trebaGasiti," +
                    "periodGasenja=:k_periodGasenja, proraditCe=:k_proraditCe, putaUKvaru=:k_putaUKvaru where id=:id";
                cmd.CommandText = sqlInsert;
                OracleParameter id = new OracleParameter();
                id.Value = aparati[index].ID;
                id.ParameterName = "id";

                OracleParameter k_tip = new OracleParameter();
                k_tip.Value = aparati[index].tip;
                k_tip.ParameterName = "k_tip";


                OracleParameter k_zauzet = new OracleParameter();
                k_zauzet.Value = aparati[index].zauzet;
                k_zauzet.ParameterName = "k_zauzet";

                OracleParameter k_uKvaru = new OracleParameter();
                k_uKvaru.Value = aparati[index].uKvaru;
                k_uKvaru.ParameterName = "k_uKvaru";


                OracleParameter k_trebaGasiti = new OracleParameter();
                k_trebaGasiti.Value = aparati[index].trebaGasiti;
                k_trebaGasiti.ParameterName = "k_trebaGasiti";

                OracleParameter k_periodGasenja = new OracleParameter();
                k_periodGasenja.Value = aparati[index].periodGasenja;
                k_periodGasenja.ParameterName = "k_periodGasenja";

                OracleParameter k_proraditCe = new OracleParameter();
                k_proraditCe.Value = aparati[index].proraditCe;
                k_proraditCe.ParameterName = "k_proraditCe";

                OracleParameter k_putaUKvaru = new OracleParameter();
                k_putaUKvaru.Value = aparati[index].periodGasenja;
                k_putaUKvaru.ParameterName = "k_putaUKvaru";

                cmd.Parameters.Add(k_putaUKvaru);
                cmd.Parameters.Add(k_tip);
                cmd.Parameters.Add(k_trebaGasiti);
                cmd.Parameters.Add(k_uKvaru);
                cmd.Parameters.Add(k_zauzet);
                cmd.Parameters.Add(k_periodGasenja);
                cmd.Parameters.Add(k_proraditCe);
                cmd.Parameters.Add(id);
                int i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                aparati[index] = a;
                return i;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int editPregleda(int index, Pregled p)
        {
            try
            {
                OracleCommand cmd = konekcija.CreateCommand();
                string sqlInsert = "update pregledi set opisPregleda=:k_opisPregleda, doktorID=:k_doktorID," +
                    "pacijentID=:k_pacijentID, ordinacijaID=:k_ordinacijaID, hitan=:k_hitan, obavljen=:k_obavljen," +
                    "termin=:k_termin, cijena=:k_cijena  where id=:id";
                cmd.CommandText = sqlInsert;
                OracleParameter id = new OracleParameter();
                id.Value = pregledi[index].ID;
                id.ParameterName = "id";

                OracleParameter k_opisPregleda = new OracleParameter();
                k_opisPregleda.Value = pregledi[index].opisPregleda;
                k_opisPregleda.ParameterName = "k_opisPregleda";


                OracleParameter k_doktorID = new OracleParameter();
                k_doktorID.Value = pregledi[index].doktorID;
                k_doktorID.ParameterName = "k_doktorID";

                OracleParameter k_pacijentID = new OracleParameter();
                k_pacijentID.Value = pregledi[index].pacijentID;
                k_pacijentID.ParameterName = "k_pacijentID";


                OracleParameter k_ordinacijaID = new OracleParameter();
                k_ordinacijaID.Value = pregledi[index].ordinacijaID;
                k_ordinacijaID.ParameterName = "k_ordinacijaID";

                OracleParameter k_hitan = new OracleParameter();
                k_hitan.Value = pregledi[index].hitan;
                k_hitan.ParameterName = "k_hitan";

                OracleParameter k_obavljen = new OracleParameter();
                k_obavljen.Value = pregledi[index].obavljen;
                k_obavljen.ParameterName = "k_obavljen";

                OracleParameter k_termin = new OracleParameter();
                k_termin.Value = pregledi[index].termin;
                k_termin.ParameterName = "k_termin";

                OracleParameter k_cijena = new OracleParameter();
                k_cijena.Value = pregledi[index].cijena;
                k_cijena.ParameterName = "k_cijena";

                cmd.Parameters.Add(k_termin);
                cmd.Parameters.Add(k_ordinacijaID);
                cmd.Parameters.Add(k_pacijentID);
                cmd.Parameters.Add(k_doktorID);
                cmd.Parameters.Add(k_hitan);
                cmd.Parameters.Add(k_obavljen);
                cmd.Parameters.Add(k_opisPregleda);
                cmd.Parameters.Add(id);
                cmd.Parameters.Add(k_cijena);
                int i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                pregledi[index] = p;
                return i;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void otvoriKonekciju()
        {
            try
            {
                konekcija = new OracleConnection();
                konekcija.ConnectionString = @"Data Source=
                (DESCRIPTION =
                        (ADDRESS = (PROTOCOL = TCP)(HOST = 80.65.65.66)(PORT = 1521))
                        (CONNECT_DATA =
                        (SERVER = DEDICATED)
                        (SERVICE_NAME = etflab.db.lab.etf.unsa.ba)
    
                        )
                    )
                ;User Id= EG17736;Password= dXh346HT;Persist Security Info=True;";
                konekcija.Open();
            }
            catch (Exception e)
            {
                //ovdje se moze upisati koji je exception bio u log datoteku a zatim se moze dalje baciti da forma javi korisniku da je doslo do problema
                throw e;
            }
        }

        //zatvara konekciju na oracle bazu 
        public void zatvoriKonekciju()
        {
            try
            {
                konekcija.Close();
            }
            catch (Exception e)
            {
                //ovdje se moze upisati koji je exception bio u log datoteku a zatim se moze dalje baciti da forma javi korisniku da je doslo do problema
                throw e;
            }
        }

        public void kreirajPocetneTabele()
        {
            OracleCommand cmd = konekcija.CreateCommand();
            //kreiranje tabele zaposlenici
            {
                cmd.CommandText = "CREATE SEQUENCE SequenceTest_Sequence " +
                            "START WITH 1 INCREMENT BY 1";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();

                cmd.CommandText = "CREATE TABLE zaposlenici(ID int PRIMARY KEY,imeIprezime varchar(255),DatumRodjenja DATE, plata Number(6), tipPosla varchar(30), username varchar(100), Md5pass varchar(100))";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();
                //trigger koji koristi sekvencu
                cmd.CommandText = "CREATE OR REPLACE TRIGGER trigger_name BEFORE INSERT ON zaposlenici FOR EACH ROW BEGIN :new.id := SequenceTest_Sequence.nextval;END;";
                cmd.ExecuteNonQuery();
            }

            //kreiranje tabele pacijenti
            {
                cmd = konekcija.CreateCommand();
                cmd.CommandText = "CREATE SEQUENCE SequenceTest_Sequence1 " +
                            "START WITH 1 INCREMENT BY 1";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();

                cmd.CommandText = "CREATE TABLE pacijenti(ID int PRIMARY KEY,imeIprezime varchar(255), DatumRodjenja DATE, jmbg Number(13), spol varchar(6), uBraku int, adresa varchar(100), prvaPomoc varchar(250), datumPrijema DATE, razlogSmrti varchar(100), vrijemeSmrti DATE, terminObdukcije DATE)";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();
                //trigger koji koristi sekvencu
                cmd.CommandText = "CREATE OR REPLACE TRIGGER trigger_name9 BEFORE INSERT ON pacijenti FOR EACH ROW BEGIN :new.id := SequenceTest_Sequence1.nextval;END;";
                cmd.ExecuteNonQuery();
            }


            //kreiranje tabele kartoni
            {
                cmd = konekcija.CreateCommand();
                cmd.CommandText = "CREATE SEQUENCE SequenceTest_Sequence2 " +
                            "START WITH 1 INCREMENT BY 1";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();
                cmd.CommandText = "CREATE TABLE kartoni(ID int PRIMARY KEY, pacijentID int , prethodneAlergije varchar (100), prethodneBolesti varchar(100), alergije varchar(100), bolesti varchar(100), username varchar(100) NOT NULL, Pass varchar(100) NOT NULL, otvoren int, termin DATE)";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();
                //trigger koji koristi sekvencu
                cmd.CommandText = "CREATE OR REPLACE TRIGGER trigger_name1 BEFORE INSERT ON kartoni FOR EACH ROW BEGIN :new.id := SequenceTest_Sequence2.nextval;END;";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();
                // constraint za foreign key
                cmd.CommandText = "ALTER TABLE kartoni ADD CONSTRAINT c_za_fk FOREIGN KEY (pacijentID) REFERENCES pacijenti(id) ";
                cmd.ExecuteNonQuery();
            }


            // kreiranje tabele doktori
            {
                cmd.CommandText = "CREATE SEQUENCE SequenceTest_Sequence3 " +
                            "START WITH 1 INCREMENT BY 1";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();

                cmd.CommandText = "CREATE TABLE doktori (ID int PRIMARY KEY,imeIprezime varchar(255), DatumRodjenja DATE, plata Number(6), tipPosla varchar(30), username varchar(100), Md5pass varchar(100), brojPacijenataDan int, brojPacijenataUkupno int, bonus Number, dostupan int, vracaSe DATE )";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();
                //trigger koji koristi sekvencu
                cmd.CommandText = "CREATE OR REPLACE TRIGGER trigger_name2 BEFORE INSERT ON doktori FOR EACH ROW BEGIN :new.id := SequenceTest_Sequence3.nextval;END;";
                cmd.ExecuteNonQuery();
            }

            //kreiranje tabele aparati
            {
                cmd.CommandText = "CREATE SEQUENCE SequenceTest_Sequence4 " +
                            "START WITH 1 INCREMENT BY 1";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();

                cmd.CommandText = "CREATE TABLE aparati (ID int PRIMARY KEY, tip varchar(50), zauzet int, uKvaru int , trebaGasiti int, periodGasenja DATE, proraditCe DATE, putaUKvaru int)";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();
                //trigger koji koristi sekvencu
                cmd.CommandText = "CREATE OR REPLACE TRIGGER trigger_name3 BEFORE INSERT ON aparati FOR EACH ROW BEGIN :new.id := SequenceTest_Sequence4.nextval;END;";
                cmd.ExecuteNonQuery();
            }

            // kreiranje tabele ordinacije
            {
                cmd.CommandText = "CREATE SEQUENCE SequenceTest_Sequence99 " +
                            "START WITH 1 INCREMENT BY 1";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();

                cmd.CommandText = "CREATE TABLE ordinacije (ID int PRIMARY KEY,poljeMedicine varchar(50) , dostupna int, doktorID int, imaAparat int, aparatID int, " +
                    "CONSTRAINT c_za_fk1 FOREIGN KEY (doktorID) REFERENCES doktori(id) ," +
                    "CONSTRAINT c_za_fk2 FOREIGN KEY (aparatID) REFERENCES aparati(id))";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();
                //trigger koji koristi sekvencu
                cmd.CommandText = "CREATE OR REPLACE TRIGGER trigger_name4 BEFORE INSERT ON ordinacije FOR EACH ROW BEGIN :new.id := SequenceTest_Sequence4.nextval;END;";
                cmd.ExecuteNonQuery();
                
            }

            // kreiranje tabele pregledi
            {
                cmd.CommandText = "CREATE SEQUENCE SequenceTest_Sequence5 " +
                                "START WITH 1 INCREMENT BY 1";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();

                cmd.CommandText = "CREATE TABLE pregledi (ID int PRIMARY KEY, opisPregleda varchar(300), doktorID int, pacijentID int, ordinacijaID int, hitan int, obavljen int, termin DATE, cijena NUMBER, " +
                    "CONSTRAINT constraint FOREIGN KEY (doktorID) REFERENCES doktori(ID)," +
                    "CONSTRAINT constraint1 FOREIGN KEY (pacijentID) REFERENCES pacijenti(ID)," +
                    "CONSTRAINT constraint2 FOREIGN KEY (ordinacijaID) REFERENCES ordinacije(ID) )";
                cmd.ExecuteNonQuery();
                cmd = konekcija.CreateCommand();
                //trigger koji koristi sekvencu
                cmd.CommandText = "CREATE OR REPLACE TRIGGER trigger_nam BEFORE INSERT ON aparati FOR EACH ROW BEGIN :new.id := SequenceTest_Sequence5.nextval;END;";
                cmd.ExecuteNonQuery();
            }
        }

        public void obrisiTabele()
        {
            OracleCommand cmd = konekcija.CreateCommand();
            cmd = konekcija.CreateCommand();
            cmd.CommandText = " DROP TABLE pregledi";
            cmd.ExecuteNonQuery();

           
                cmd.CommandText = " DROP TABLE zaposlenici";
                cmd.ExecuteNonQuery();

            cmd = konekcija.CreateCommand();
            cmd.CommandText = " DROP TABLE kartoni";
            cmd.ExecuteNonQuery();


            cmd = konekcija.CreateCommand();
            cmd.CommandText = " DROP TABLE pacijenti";
            cmd.ExecuteNonQuery();

            
            cmd = konekcija.CreateCommand();
            cmd.CommandText = " DROP TABLE ordinacije";
            cmd.ExecuteNonQuery();

            cmd = konekcija.CreateCommand();
            cmd.CommandText = " DROP TABLE aparati";
            cmd.ExecuteNonQuery();

            cmd = konekcija.CreateCommand();
            cmd.CommandText = " DROP TABLE doktori";
            cmd.ExecuteNonQuery();

            

            cmd = konekcija.CreateCommand();
            cmd.CommandText = "DROP SEQUENCE SequenceTest_Sequence ";
            cmd.ExecuteNonQuery();

            cmd = konekcija.CreateCommand();
            cmd.CommandText = "DROP SEQUENCE SequenceTest_Sequence1 ";
            cmd.ExecuteNonQuery();


            cmd = konekcija.CreateCommand();
            cmd.CommandText = "DROP SEQUENCE SequenceTest_Sequence2 ";
            cmd.ExecuteNonQuery();


            cmd = konekcija.CreateCommand();
            cmd.CommandText = "DROP SEQUENCE SequenceTest_Sequence3 ";
            cmd.ExecuteNonQuery();


            cmd = konekcija.CreateCommand();
            cmd.CommandText = "DROP SEQUENCE SequenceTest_Sequence4 ";
            cmd.ExecuteNonQuery();

            cmd = konekcija.CreateCommand();
            cmd.CommandText = "DROP SEQUENCE SequenceTest_Sequence5 ";
            cmd.ExecuteNonQuery();

            cmd = konekcija.CreateCommand();
            cmd.CommandText = "DROP SEQUENCE SequenceTest_Sequence99 ";
            cmd.ExecuteNonQuery();
            /*
            cmd = konekcija.CreateCommand();
            cmd.CommandText = "DROP CONSTRAINT c_za_fk ";
            cmd.ExecuteNonQuery();

            cmd = konekcija.CreateCommand();
            cmd.CommandText = "DROP CONSTRAINT c_za_fk1 ";
            cmd.ExecuteNonQuery();

            cmd = konekcija.CreateCommand();
            cmd.CommandText = "DROP CONSTRAINT c_za_fk2 ";
            cmd.ExecuteNonQuery();

            cmd = konekcija.CreateCommand();
            cmd.CommandText = "DROP CONSTRAINT constraint ";
            cmd.ExecuteNonQuery();

            cmd = konekcija.CreateCommand();
            cmd.CommandText = "DROP CONSTRAINT constraint1 ";
            cmd.ExecuteNonQuery();

            cmd = konekcija.CreateCommand();
            cmd.CommandText = "DROP CONSTRAINT constraint2 ";
            cmd.ExecuteNonQuery();*/
        }

        // insertovanje
        public int spasiZaposlenika(Zaposleni zaposlenik)
        {
            OracleCommand cmd = konekcija.CreateCommand();
            string sqlInsert = "insert into zaposlenici (imeIprezime, datumRodjenja, plata, tipPosla, username, Md5hash) ";
            sqlInsert += "values (:k_ImePrezime, :k_DatumRodjenja, :k_plata,:k_TipPosla :k_Username, :k_Password)";
            cmd.CommandText = sqlInsert;

            OracleParameter k_ImePrezime = new OracleParameter();
            k_ImePrezime.Value = zaposlenik.imeIprezime;
            k_ImePrezime.ParameterName = "k_ImePrezime";

            OracleParameter k_DatumRodjenja = new OracleParameter();
            k_DatumRodjenja.Value = zaposlenik.datumRodjenja;
            k_DatumRodjenja.ParameterName = "k_DatumROdjenja";

            OracleParameter k_plata = new OracleParameter();
            k_plata.Value = zaposlenik.plata;
            k_plata.ParameterName = "k_plata";

            OracleParameter k_TipPosla = new OracleParameter();
            k_TipPosla.Value = zaposlenik.tipPosla;
            k_TipPosla.ParameterName = "k_TipPosla";

            OracleParameter k_Username = new OracleParameter();
            k_Username.Value = zaposlenik.username;
            k_Username.ParameterName = "k_Username";

            OracleParameter k_Password = new OracleParameter();
            k_Password.Value = zaposlenik.Md5pass;
            k_Password.ParameterName = "k_Password";


            cmd.Parameters.Add(k_ImePrezime);
            cmd.Parameters.Add(k_plata);
            cmd.Parameters.Add(k_TipPosla);
            cmd.Parameters.Add(k_Username);
            cmd.Parameters.Add(k_Password);
            cmd.Parameters.Add(k_DatumRodjenja);
            int k = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return k;
        }

        public int spasiDoktora(Doktor d)
        {
            OracleCommand cmd = konekcija.CreateCommand();
            string sqlInsert = "insert into doktori (imeIprezime, datumRodjenja, plata, tipPosla, username, Md5hash, brojPacijenataDan, brojPacijenataUkupno," +
                "bonus, dostupan, vracaSe) ";
            sqlInsert += "values (:k_ImePrezime, :k_DatumRodjenja, :k_plata,:k_TipPosla :k_Username, :k_Password, :k_brDan, :k_brUk, :k_bonus, :k_dostupan, :k_vracaSe)";
            cmd.CommandText = sqlInsert;


            OracleParameter k_ImePrezime = new OracleParameter();
            k_ImePrezime.Value = d.imeIprezime;
            k_ImePrezime.ParameterName = "k_ImePrezime";

            OracleParameter k_Plata = new OracleParameter();
            k_Plata.Value = d.plata;
            k_Plata.ParameterName = "k_Plata";

            OracleParameter k_DatumRodjenja = new OracleParameter();
            k_DatumRodjenja.Value = d.datumRodjenja;
            k_DatumRodjenja.ParameterName = "k_DatumRodjenja";

            OracleParameter k_TipPosla = new OracleParameter();
            k_TipPosla.Value = d.tipPosla.ToString();
            k_TipPosla.ParameterName = "k_TipPosla";

            OracleParameter k_Username = new OracleParameter();
            k_Username.Value = d.username;
            k_Username.ParameterName = "k_Username";

            OracleParameter k_MD5pass = new OracleParameter();
            k_MD5pass.Value = d.Md5pass;
            k_MD5pass.ParameterName = "k_MD5pass";

            OracleParameter k_brDan = new OracleParameter();
            k_brDan.Value = d.brojPacijenataDan;
            k_brDan.ParameterName = "k_brDan";

            OracleParameter k_brUk = new OracleParameter();
            k_brUk.Value = d.brojPacijenataUkupno;
            k_brUk.ParameterName = "k_brUk";

            OracleParameter k_bonus = new OracleParameter();
            k_bonus.Value = d.Bonus;
            k_bonus.ParameterName = "k_bonus";

            OracleParameter k_vracaSe = new OracleParameter();
            k_MD5pass.Value = d.vracaSe;
            k_MD5pass.ParameterName = "k_vracaSe";

            OracleParameter k_dostupan = new OracleParameter();
            k_dostupan.Value = d.dostupan;
            k_dostupan.ParameterName = "k_dostupan";

            cmd.Parameters.Add(k_ImePrezime);
            cmd.Parameters.Add(k_MD5pass);
            cmd.Parameters.Add(k_Plata);
            cmd.Parameters.Add(k_TipPosla);
            cmd.Parameters.Add(k_Username);
            cmd.Parameters.Add(k_DatumRodjenja);
            cmd.Parameters.Add(k_brDan);
            cmd.Parameters.Add(k_brUk);
            cmd.Parameters.Add(k_bonus);
            cmd.Parameters.Add(k_dostupan);
            cmd.Parameters.Add(k_vracaSe);
            int k = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return k;
        }

        public int spasiPacijenta(HitniPacijent pac)
        {
            OracleCommand cmd = konekcija.CreateCommand();
            string sqlInsert = "insert into pacijenti (imeIprezime, datumRodjenja, jmbg, spol, uBraku, adresa, datumPrijema, prvaPomoc, razlogSmrti, vrijemeSmrti, terminObdukcije) ";
            sqlInsert += "values (:k_ImePrezime, :k_DatumRodjenja, :k_jmbg,:k_spol, :k_uBraku, :k_adresa, :k_datPrij, :k_pp, :k_uzrok, :k_vrijeme, :k_obdukcija)";
            cmd.CommandText = sqlInsert;

            OracleParameter k_ImePrezime = new OracleParameter();
            k_ImePrezime.Value = pac.imeIprezime;
            k_ImePrezime.ParameterName = "k_ImePrezime";


            OracleParameter k_DatumRodjenja = new OracleParameter();
            k_DatumRodjenja.Value = pac.datumRodjenja;
            k_DatumRodjenja.ParameterName = "k_DatumRodjenja";

            OracleParameter k_jmbg = new OracleParameter();
            k_jmbg.Value = pac.jmbg;
            k_jmbg.ParameterName = "k_jmbg";

            OracleParameter k_spol = new OracleParameter();
            k_spol.Value = pac.spol.ToString();
            k_spol.ParameterName = "k_spol";

            OracleParameter k_uBraku = new OracleParameter();
            k_uBraku.Value = pac.uBraku;
            k_uBraku.ParameterName = "k_uBraku";

            OracleParameter k_adresa = new OracleParameter();
            k_adresa.Value = pac.adresa;
            k_adresa.ParameterName = "k_adresa";

            OracleParameter k_datPrij = new OracleParameter();
            k_datPrij.Value = pac.datumPrijema;
            k_datPrij.ParameterName = "k_datPrij";

            OracleParameter k_pp = new OracleParameter();
            k_pp.Value = pac.prvaPomoc;
            k_pp.ParameterName = "k_pp";

            OracleParameter k_uzrok = new OracleParameter();
            k_uzrok.Value = pac.razlogSmrti;
            k_uzrok.ParameterName = "k_uzrok";

            OracleParameter k_vrijeme = new OracleParameter();
            k_vrijeme.Value = pac.vrijemeSmrti;
            k_vrijeme.ParameterName = "k_vrijeme";

            OracleParameter k_obdukcija = new OracleParameter();
            k_obdukcija.Value = pac.terminObdukcije;
            k_obdukcija.ParameterName = "k_obdukcija";


            cmd.Parameters.Add(k_ImePrezime);
            cmd.Parameters.Add(k_DatumRodjenja);
            cmd.Parameters.Add(k_jmbg);
            cmd.Parameters.Add(k_spol);
            cmd.Parameters.Add(k_uBraku);
            cmd.Parameters.Add(k_adresa);
            cmd.Parameters.Add(k_datPrij);
            cmd.Parameters.Add(k_pp);
            cmd.Parameters.Add(k_uzrok);
            cmd.Parameters.Add(k_vrijeme);
            cmd.Parameters.Add(k_obdukcija);
            int k = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return k;
        } 

        public int spasiPregled(Pregled p)
        {
            OracleCommand cmd = konekcija.CreateCommand();
            string sqlInsert = "insert into pregledi (opisPregleda, doktorID, pacijentID, ordinacijaID, hitan, obavljen, termin, cijena) ";
            sqlInsert += "values (:k_opisPregleda, :k_doktorID, :k_pacijentID, :k_ordinacijaID, :k_hitan, :k_obavljen, :k_termin, :k_cijena)";
            cmd.CommandText = sqlInsert;

            OracleParameter k_opisPregleda = new OracleParameter();
            k_opisPregleda.Value = p.opisPregleda;
            k_opisPregleda.ParameterName = "k_opisPregleda";


            OracleParameter k_doktorID = new OracleParameter();
            k_doktorID.Value = p.doktorID;
            k_doktorID.ParameterName = "k_doktorID";

            OracleParameter k_pacijentID = new OracleParameter();
            k_pacijentID.Value = p.pacijentID;
            k_pacijentID.ParameterName = "k_pacijentID";


            OracleParameter k_ordinacijaID = new OracleParameter();
            k_ordinacijaID.Value = p.ordinacijaID;
            k_ordinacijaID.ParameterName = "k_ordinacijaID";

            OracleParameter k_hitan = new OracleParameter();
            k_hitan.Value = p.hitan;
            k_hitan.ParameterName = "k_hitan";

            OracleParameter k_obavljen = new OracleParameter();
            k_obavljen.Value = p.obavljen;
            k_obavljen.ParameterName = "k_obavljen";

            OracleParameter k_termin = new OracleParameter();
            k_termin.Value = p.termin;
            k_termin.ParameterName = "k_termin";

            OracleParameter k_cijena = new OracleParameter();
            k_cijena.Value = p.cijena;
            k_cijena.ParameterName = "k_cijena";

            cmd.Parameters.Add(k_termin);
            cmd.Parameters.Add(k_ordinacijaID);
            cmd.Parameters.Add(k_pacijentID);
            cmd.Parameters.Add(k_doktorID);
            cmd.Parameters.Add(k_hitan);
            cmd.Parameters.Add(k_obavljen);
            cmd.Parameters.Add(k_opisPregleda);
            cmd.Parameters.Add(k_cijena);
            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return i;
        }

        public int spasiKarton(Karton kar)
        {
            OracleCommand cmd = konekcija.CreateCommand();
            string sqlInsert = "insert into kartoni (pacijendID, prethodneAlergije, prethodneBolesti, alergije, bolesti, username, Pass, otvoren, termin) ";
            sqlInsert += "values (:k_pacid, :k_palg, :k_pbol, :k_alergije, :k_bolesti, :k_username, :k_pass, :k_otvoren, :k_termin)";
            cmd.CommandText = sqlInsert;


            OracleParameter k_pacid = new OracleParameter();
            k_pacid.Value = kar.pacijentID;
            k_pacid.ParameterName = "k_pacid";


            OracleParameter k_palg = new OracleParameter();
            k_palg.Value = kar.prethodneAlergije;
            k_palg.ParameterName = "k_palg";

            OracleParameter k_pbol = new OracleParameter();
            k_pbol.Value = kar.prethodneBolesti;
            k_pbol.ParameterName = "k_pbol";

            OracleParameter k_alergije = new OracleParameter();
            k_alergije.Value = kar.alergije;
            k_alergije.ParameterName = "k_alergije";

            OracleParameter k_bolesti = new OracleParameter();
            k_bolesti.Value = kar.bolesti;
            k_bolesti.ParameterName = "k_bolesti";

            OracleParameter k_username = new OracleParameter();
            k_username.Value = kar.username;
            k_username.ParameterName = "k_username";

            OracleParameter k_pass = new OracleParameter();
            k_pass.Value = kar.Pass;
            k_pass.ParameterName = "k_pass";

            OracleParameter k_otvoren = new OracleParameter();
            k_otvoren.Value = kar.otvoren;
            k_otvoren.ParameterName = "k_otvoren";

            OracleParameter k_termin = new OracleParameter();
            k_termin.Value = kar.termin;
            k_termin.ParameterName = "k_termin";

            cmd.Parameters.Add(k_pacid);
            cmd.Parameters.Add(k_palg);
            cmd.Parameters.Add(k_pbol);
            cmd.Parameters.Add(k_alergije);
            cmd.Parameters.Add(k_bolesti);
            cmd.Parameters.Add(k_otvoren);
            cmd.Parameters.Add(k_termin);
            cmd.Parameters.Add(k_username);
            cmd.Parameters.Add(k_pass);
            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return i;
        }

        public int spasiOrdinacijiu(Ordinacija ord)
        {
            OracleCommand cmd = konekcija.CreateCommand();
            string sqlInsert = "insert into ordinacije (id, poljeMedicine, dostupna, doktorID, imaAparat, aparatID) ";
            sqlInsert += "values (:k_id, :k_tip, :k_dostupna, :k_doktorID, :k_imaAparat, :k_aparatID)";
            cmd.CommandText = sqlInsert;

            OracleParameter k_id = new OracleParameter();
            k_id.Value = ord.ID;
            k_id.ParameterName = "k_id";

            OracleParameter k_tip = new OracleParameter();
            k_tip.Value = ord.poljeMedicine.ToString();
            k_tip.ParameterName = "k_tip";


            OracleParameter k_dostupna = new OracleParameter();
            k_dostupna.Value = ord.dostupna;
            k_dostupna.ParameterName = "k_dostupna";

            OracleParameter k_doktorID = new OracleParameter();
            k_doktorID.Value = ord.doktorId;
            k_doktorID.ParameterName = "k_doktorID";

            OracleParameter k_imaap = new OracleParameter();
            k_imaap.Value = ord.imaAparat;
            k_imaap.ParameterName = "k_imaap";

            OracleParameter k_aparatID = new OracleParameter();
            k_aparatID.Value = ord.aparatId;
            k_aparatID.ParameterName = "k_aparatID";

            cmd.Parameters.Add(k_aparatID);
            cmd.Parameters.Add(k_doktorID);
            cmd.Parameters.Add(k_dostupna);
            cmd.Parameters.Add(k_imaap);
            cmd.Parameters.Add(k_tip);
            cmd.Parameters.Add(k_id);
            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return i;
        }

        public int spasiAparat(Aparat a)
        {
            OracleCommand cmd = konekcija.CreateCommand();
            string sqlInsert = "insert into aparati (tip, zauzet, uKvaru, trebaGasiti, periodGasenja, proraditCe, putaUKvaru) ";
            sqlInsert += "values (:k_tip, :k_zauzet, :k_uKvaru, :k_trebaGasiti, :k_periodGasenja, :k_proraditCe, :k_putaUKvaru)";
            cmd.CommandText = sqlInsert;

            OracleParameter k_tip = new OracleParameter();
            k_tip.Value = a.tip;
            k_tip.ParameterName = "k_tip";


            OracleParameter k_zauzet = new OracleParameter();
            k_zauzet.Value = a.zauzet;
            k_zauzet.ParameterName = "k_zauzet";

            OracleParameter k_uKvaru = new OracleParameter();
            k_uKvaru.Value = a.uKvaru;
            k_uKvaru.ParameterName = "k_uKvaru";


            OracleParameter k_trebaGasiti = new OracleParameter();
            k_trebaGasiti.Value = a.trebaGasiti;
            k_trebaGasiti.ParameterName = "k_trebaGasiti";

            OracleParameter k_periodGasenja = new OracleParameter();
            k_periodGasenja.Value = a.periodGasenja;
            k_periodGasenja.ParameterName = "k_periodGasenja";

            OracleParameter k_proraditCe = new OracleParameter();
            k_proraditCe.Value = a.proraditCe;
            k_proraditCe.ParameterName = "k_proraditCe";

            OracleParameter k_putaUKvaru = new OracleParameter();
            k_putaUKvaru.Value = a.periodGasenja;
            k_putaUKvaru.ParameterName = "k_putaUKvaru";

            cmd.Parameters.Add(k_putaUKvaru);
            cmd.Parameters.Add(k_tip);
            cmd.Parameters.Add(k_trebaGasiti);
            cmd.Parameters.Add(k_uKvaru);
            cmd.Parameters.Add(k_zauzet);
            cmd.Parameters.Add(k_periodGasenja);
            cmd.Parameters.Add(k_proraditCe);
            int i = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return i;
        }

        //Priprema data set za data grid i povezuje tabelu sa data gridom
        public void dataSetZaposlenici(string tabela)
        {
            string iskaz="";
            if (tabela == "zaposlenici") iskaz = "SELECT * FROM zaposlenici";
            else if (tabela == "pacijenti") iskaz = "SELECT * FROM pacijenti";
            else if (tabela == "doktori") iskaz = "SELECT * FROM doktori";
            else if (tabela == "kartoni") iskaz = "SELECT * FROM kartoni";
            else if (tabela == "aparti") iskaz = "SELECT * FROM aparati";
            else if (tabela == "ordinacije") iskaz = "SELECT * FROM ordinacije";
            dataAdapter = new OracleDataAdapter(iskaz, konekcija);
            OracleCommandBuilder builder = new OracleCommandBuilder(dataAdapter);
            dataAdapter.InsertCommand = builder.GetInsertCommand();
            dataAdapter.UpdateCommand = builder.GetUpdateCommand();
            dataAdapter.DeleteCommand = builder.GetDeleteCommand();
            DataSet = new DataSet();
            dataAdapter.Fill(DataSet);
        }

    }
}
