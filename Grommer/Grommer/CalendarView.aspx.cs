using System;
using System.Data;

using System.Web.UI.WebControls;

public partial class CalendarView : System.Web.UI.Page
{
    #region global Variable
    int GId;

    Groomer objGroomer = new Groomer();
    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                GId = Convert.ToInt32(Session["GId"].ToString());
                if (!(null == Session["PageFrom"]))
                {
                    string chk = Session["PageFrom"].ToString();
                    if (chk == "OP" || chk == "OPR")
                    {
                        DateTime dt = Session["NextDate"] != null ? Convert.ToDateTime(Session["NextDate"].ToString()) : DateTime.Now;
                        calapptDate.SelectedDate = dt;
                        lblStart.Text = Session["NextStartTime"] != null ? Session["NextStartTime"].ToString() : string.Empty;
                        lblEnd.Text = Session["NextEndTime"] != null ? Session["NextEndTime"].ToString() : string.Empty; ;
                        pnlRebook.Visible = true;
                        GetAllAppointment(dt);
                    }
                    else GetAllAppointment(DateTime.Now);
                }
                else GetAllAppointment(DateTime.Now);
            }
            catch
            {
                Response.Redirect("Dashboard.aspx", false);
            }
        }
    }
    #endregion PageLoad

    #region Comment
    //protected void calDate_DayRender(object sender, DayRenderEventArgs e)
    //{

    //    if (e.Day.Date < DateTime.Now.Date)
    //    {
    //        //  e.Cell.BackColor = System.Drawing.Color.LightGray;
    //        //  e.Day.IsSelectable = false;

    //    }


    //}

    //protected void calDate_SelectionChanged(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        lbldtval.Text = Convert.ToDateTime(calapptDate.SelectedDate.Date.ToString()).Date.ToString("dd-MMM-yyyy");
    //        Groomer objGroomer = new Groomer();

    //        PnldispAppt.Visible = true;
    //        Pnldispapptdet.Visible = false;


    //        DataTable dtAppts = new DataTable();
    //        dtAppts.Columns.Add("TIME");
    //        dtAppts.Columns.Add("ZIPCODE");
    //        dtAppts.Columns.Add("CNAME");
    //        dtAppts.Columns.Add("GroomerAppointmentId");

    //        int iGId = 0;

    //        if (!(null == Session["GId"]))
    //        {
    //            iGId = Convert.ToInt32(Session["GId"].ToString());
    //        }

    //        int tm_min = 0;
    //        string Start_Index = "";

    //        for (int time = 6; time <= 21; time++)
    //        {


    //            DataSet dsAppt = new DataSet();
    //            //string userZone = Session["UserTimeZone"].ToString();
    //            //var info = TimeZoneInfo.FindSystemTimeZoneById(userZone);

    //            //DateTimeOffset localServerTime = calapptDate.SelectedDate.Date;

    //            //DateTimeOffset usersTime = TimeZoneInfo.ConvertTime(localServerTime, info);
    //            //string convertedTime = usersTime.DateTime.ToLongDateString();

    //            //dsAppt = objGroomer.GetApptSchedules(Convert.ToDateTime(convertedTime), time, iGId);
    //            DateTime dte=Convert.ToDateTime(calapptDate.SelectedDate.Date.ToString());
    //           dsAppt = objGroomer.GetApptSchedules(Convert.ToDateTime(calapptDate.SelectedDate.Date.ToString()), time, iGId);


    //            string ampm = " AM";
    //            string STime = time.ToString();
    //            string MTime = time.ToString();
    //            if (time >= 12)
    //            {
    //                ampm = " PM";
    //                //      STime = (time - 12).ToString();
    //                if (time != 12)
    //                {
    //                    MTime = (time - 12).ToString();
    //                }
    //            }

    //            string tm = MTime.ToString() + ":00" + ampm;

    //            if (dsAppt.Tables.Count > 0)
    //            {
    //                if (dsAppt.Tables[0].Rows.Count > 0)
    //                {
    //                    int Record_Count = 0;
    //                    int RowsAdded = 0;
    //                    tm_min = 0;
    //                    foreach (DataRow dr in dsAppt.Tables[0].Rows)
    //                    {
    //                        Record_Count++;

    //                        tm_min = 0;
    //                        string fromhh = "", fromm = "", tohh = "", tomm = "";

    //                        if (dr["FROMHOURS"].ToString() != "" && dr["FROMMINUTES"].ToString() != "" && dr["TOHOURS"].ToString() != "" && dr["TOMINUTES"].ToString() != "")
    //                        {

    //                            fromhh = dr["FROMHOURS"].ToString();
    //                            fromm = dr["FROMMINUTES"].ToString();
    //                            tohh = dr["TOHOURS"].ToString();
    //                            tomm = dr["TOMINUTES"].ToString();


    //                        }

    //                        string NextFromHours = "", NextFromMins = "", NextToHours = "", NextToMins = "";
    //                        int Nextrowid = Record_Count;
    //                        if (Record_Count < dsAppt.Tables[0].Rows.Count)
    //                        {
    //                            NextFromHours = dsAppt.Tables[0].Rows[Nextrowid]["FROMHOURS"].ToString();
    //                            NextFromMins = dsAppt.Tables[0].Rows[Nextrowid]["FROMMINUTES"].ToString();
    //                            NextToHours = dsAppt.Tables[0].Rows[Nextrowid]["TOHOURS"].ToString();
    //                            NextToMins = dsAppt.Tables[0].Rows[Nextrowid]["TOMINUTES"].ToString();
    //                        }


    //                        // To Manage the overlapping appointments.so the appts. can not be overlap.

    //                        bool IsValidEntry = true;
    //                        if (dsAppt.Tables[0].Rows.Count > 0 && Record_Count > 1 && Convert.ToInt32(STime) == Convert.ToInt32(fromhh))
    //                        {
    //                            int rcount = 1;

    //                            foreach (DataRow datarows in dsAppt.Tables[0].Rows)
    //                            {
    //                                if (rcount < Record_Count)
    //                                {
    //                                    if (Convert.ToInt32(fromhh) == Convert.ToInt32(datarows["FROMHOURS"]) && Convert.ToInt32(fromhh) <= Convert.ToInt32(datarows["TOHOURS"])
    //                                    && Convert.ToInt32(fromm) >= Convert.ToInt32(datarows["FROMMINUTES"]) && Convert.ToInt32(fromm) <= 60
    //                                        && (Convert.ToInt32(tohh) > Convert.ToInt32(fromhh) && Convert.ToInt32(tomm) > 0 && Convert.ToInt32(fromm) > 0) && Convert.ToInt32(fromm) != 45)
    //                                    {
    //                                        IsValidEntry = false;
    //                                        break;
    //                                    }
    //                                }
    //                                rcount++;
    //                            }
    //                        }

    //                        if (!(null == Session["STIME"]) && !(null == Session["RowsAdded"]))
    //                        {

    //                            int radded = Convert.ToInt32(Session["RowsAdded"]);
    //                            string ST = Session["STIME"].ToString();
    //                            if (radded == 4 && ST.Equals(STime))
    //                            {
    //                                IsValidEntry = false;
    //                            }

    //                            Session["RowsAdded"] = null;
    //                            Session["STIME"] = null;
    //                        }


    //                        if (IsValidEntry.Equals(false))
    //                        {
    //                            break;
    //                        }



    //                        int range1 = 0, range2 = 15;
    //                        for (int i = 0; i < 4; i++)
    //                        {
    //                            Session["IsNextRowValue"] = "";
    //                            if (fromm != "")
    //                            {
    //                                bool IsBlankRow = true;

    //                                if (!(null == Session["RangeOne"]) && !(null == Session["RangeTwo"]) && !(null == Session["Loop-Range"]))
    //                                {
    //                                    if (Session["RangeOne"].ToString() != "")
    //                                    {
    //                                        range1 = Convert.ToInt32(Session["RangeOne"].ToString());
    //                                        Session["RangeOne"] = "";

    //                                    }
    //                                    if (Session["RangeTwo"].ToString() != "")
    //                                    {
    //                                        range2 = Convert.ToInt32(Session["RangeTwo"].ToString());
    //                                        Session["RangeTwo"] = "";

    //                                    }
    //                                    if (Session["Loop-Range"].ToString() != "")
    //                                    {
    //                                        i = Convert.ToInt32(Session["Loop-Range"].ToString());
    //                                        Session["Loop-Range"] = "";

    //                                    }

    //                                }

    //                                int counter = Record_Count;
    //                                //int counter = Record_Count + 1;

    //                                while (counter < dsAppt.Tables[0].Rows.Count)
    //                                {
    //                                    string NextFHours = dsAppt.Tables[0].Rows[counter]["FROMHOURS"].ToString();
    //                                    string NextFMins = dsAppt.Tables[0].Rows[counter]["FROMMINUTES"].ToString();
    //                                    string NextTHours = dsAppt.Tables[0].Rows[counter]["TOHOURS"].ToString();
    //                                    string NextTMins = dsAppt.Tables[0].Rows[counter]["TOMINUTES"].ToString();

    //                                    if ((Convert.ToInt32(NextFMins) >= range1 && Convert.ToInt32(NextFMins) < range2 && NextFHours.Equals(fromhh) && NextTHours.Equals(fromhh)))
    //                                    //|| (Convert.ToInt32(NextFMins) == 0 && Convert.ToInt32(NextFMins) < Convert.ToInt32(fromm) && Convert.ToInt32(NextTMins) == 0 && NextFHours.Equals(fromhh) && Convert.ToInt32(NextTHours) > Convert.ToInt32(fromhh)))

    //                                    //if ((Convert.ToInt32(NextFMins) >= range1 && Convert.ToInt32(NextFMins) <= range2 && NextFHours.Equals(fromhh) && Convert.ToInt32(NextFMins) < Convert.ToInt32(fromm) && (!(fromm.Equals("0"))))
    //                                    //  || (Convert.ToInt32(NextFMins) >= range1 && Convert.ToInt32(NextFMins) <= range2 && NextFHours.Equals(fromhh) && (Convert.ToInt32(NextFMins) < Convert.ToInt32(tomm)) && (Convert.ToInt32(NextToMins) < Convert.ToInt32(tomm))))
    //                                    //if (NextFHours.Equals(fromhh) && (Convert.ToInt32(NextFMins) < Convert.ToInt32(fromm) || Convert.ToInt32(NextFMins)< Convert.ToInt32(tomm)) && Convert.ToInt32(NextTHours) > Convert.ToInt32(NextFHours) && range1 < Convert.ToInt32(fromm))
    //                                    {
    //                                        IsBlankRow = false;
    //                                        Session["IsNextRowValue"] = "1";
    //                                        break;
    //                                    }

    //                                    counter++;
    //                                }




    //                                //if (NextFromHours.Equals(fromhh) && Convert.ToInt32(NextFromMins) < Convert.ToInt32(fromm) && Convert.ToInt32(NextToHours) > Convert.ToInt32(NextFromHours) && range1 < Convert.ToInt32(fromm))
    //                                //{
    //                                //    IsBlankRow = false;
    //                                //    Session["IsNextRowValue"] = "1";
    //                                //}



    //                                //if ((Convert.ToInt32(fromm) >= range1 && Convert.ToInt32(fromm) < range2 && Convert.ToInt32(fromhh) == Convert.ToInt32(STime)) || (Convert.ToInt32(fromm) <= range1 &&  range2==60 && Convert.ToInt32(fromhh) == Convert.ToInt32(STime)) || (Convert.ToInt32(fromhh) <= Convert.ToInt32(STime) && Convert.ToInt32(tomm) > range1 && Convert.ToInt32(tohh) == Convert.ToInt32(STime)))
    //                                if ((Convert.ToInt32(fromm) < range2 && Convert.ToInt32(fromhh) == Convert.ToInt32(STime)) || (Convert.ToInt32(fromm) <= range1 && range2 <= 60 && Convert.ToInt32(fromhh) == Convert.ToInt32(STime)))
    //                                {
    //                                    IsBlankRow = false;

    //                                }


    //                                bool IsValidRec = true;
    //                                if ((Convert.ToInt32(fromhh) != Convert.ToInt32(STime) && Convert.ToInt32(tohh) != Convert.ToInt32(STime))
    //                                    || (Convert.ToInt32(tohh) == Convert.ToInt32(STime) && tomm.Equals("0")))
    //                                //                                        || (Convert.ToInt32(tohh) > Convert.ToInt32(fromhh) && Record_Count <= dsAppt.Tables[0].Rows.Count)
    //                                {
    //                                    IsValidRec = false;


    //                                }
    //                                //if(Convert.ToInt32(fromhh) != Convert.ToInt32(STime) && Convert.ToInt32(STime)<=Convert.ToInt32(tohh))
    //                                //{
    //                                //    IsValidRec = true;
    //                                //}

    //                                //if ((Convert.ToInt32(fromhh) <= Convert.ToInt32(STime) && Convert.ToInt32(tomm) > range1 && Convert.ToInt32(tohh) == Convert.ToInt32(STime)))
    //                                if ((Convert.ToInt32(fromhh) <= Convert.ToInt32(STime) && Convert.ToInt32(tomm) > range1 && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && range1 > Convert.ToInt32(fromm)) || (Convert.ToInt32(fromhh) <= Convert.ToInt32(STime) && Convert.ToInt32(tomm) > range1 && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Convert.ToInt32(fromhh) != Convert.ToInt32(tohh)))
    //                                {
    //                                    IsBlankRow = false;

    //                                }

    //                                bool IsNextr = false;
    //                                if (!(null == Session["IsNextRowValue"]))
    //                                {
    //                                    if (Session["IsNextRowValue"].ToString().Equals("1"))
    //                                    {
    //                                        IsNextr = true;
    //                                    }
    //                                }

    //                                // ex. 8:15 PM to 8:30 PM or 8:45 PM to 9:30 PM
    //                                //if (Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Convert.ToInt32(fromm) > range1)
    //                                if (Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Convert.ToInt32(fromm) > range1 && Convert.ToInt32(fromm) > range2 && IsNextr.Equals(false))
    //                                {
    //                                    IsBlankRow = true;

    //                                }

    //                                if ((Convert.ToInt32(fromhh) < Convert.ToInt32(STime) && Convert.ToInt32(tohh) > Convert.ToInt32(STime)))
    //                                {
    //                                    IsBlankRow = false;
    //                                    IsValidRec = true;

    //                                }

    //                                // for ex. 6:00 to 6:30
    //                                //&& Convert.ToInt32(fromm) != range2
    //                                if ((Convert.ToInt32(tomm) <= range1 && IsNextr.Equals(false) || Convert.ToInt32(fromm) > range2) && Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && IsNextr.Equals(false))
    //                                //original  if (Convert.ToInt32(tomm) < range1 && Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Convert.ToInt32(tohh) == Convert.ToInt32(STime))
    //                                //  if (Convert.ToInt32(fromm) > range2 && Convert.ToInt32(tomm) < range2 && Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Convert.ToInt32(tohh) == Convert.ToInt32(STime))
    //                                {
    //                                    IsBlankRow = true;
    //                                }


    //                                //if (STime.Equals("4") && IsValidRec.Equals(true))
    //                                //{
    //                                //    int a = 0;
    //                                //}




    //                                if (i <= 3 && IsValidRec.Equals(false) && dsAppt.Tables[0].Rows.Count == Record_Count)
    //                                {
    //                                    IsValidRec = true;


    //                                }




    //                                //if (dsAppt.Tables[0].Rows.Count > 0 && Record_Count > 0)
    //                                //{
    //                                //    int rcount = 0;
    //                                //    foreach (DataRow datarows in dsAppt.Tables[0].Rows)
    //                                //    {
    //                                //        if (rcount != Record_Count)
    //                                //        {
    //                                //            if (Convert.ToInt32(fromhh) >= Convert.ToInt32(datarows["FROMHOURS"]) && Convert.ToInt32(fromhh) <= Convert.ToInt32(datarows["TOHOURS"])
    //                                //            && Convert.ToInt32(fromm) >= Convert.ToInt32(datarows["FROMMINUTES"]) && Convert.ToInt32(fromm) <= Convert.ToInt32(datarows["TOMINUTES"])
    //                                //              )
    //                                //            {
    //                                //                IsValidRec = false;
    //                                //            }
    //                                //        }
    //                                //        rcount++;
    //                                //    }
    //                                //}

    //                                if (Record_Count < dsAppt.Tables[0].Rows.Count)
    //                                {

    //                                    if ((Convert.ToInt32(NextFromHours) == Convert.ToInt32(fromhh) && Convert.ToInt32(NextFromMins) == 45
    //                          && Convert.ToInt32(NextToHours) == Convert.ToInt32(fromhh) + 1 &&
    //                            Convert.ToInt32(NextToMins) == 0 && range1 >= 45) || (Convert.ToInt32(NextFromHours) == Convert.ToInt32(fromhh)
    //                                        && range1 >= Convert.ToInt32(NextFromMins) && Convert.ToInt32(NextToHours) == Convert.ToInt32(fromhh)
    //                                        && Convert.ToInt32(NextFromMins) > 0))
    //                                    {

    //                                        IsValidRec = false;
    //                                        Session["RangeOne"] = range1.ToString();
    //                                        Session["RangeTwo"] = range2.ToString();
    //                                        i = i + 1;
    //                                        Session["Loop-Range"] = i.ToString();
    //                                        break;

    //                                    }
    //                                }

    //                                if (IsBlankRow.Equals(true))
    //                                {

    //                                    if (IsValidRec.Equals(true))
    //                                    {

    //                                        DataRow dtrow = dtAppts.NewRow();
    //                                        if (i == 0)
    //                                        {
    //                                            dtrow[0] = tm;
    //                                            //Start_Index = i;
    //                                            Start_Index = tm;
    //                                        }
    //                                        else
    //                                        {
    //                                            dtrow[0] = "";
    //                                            //    tm_min = tm_min + 15;
    //                                            //   dtrow[0] = MTime.ToString() + ":" + (tm_min).ToString() + ampm;
    //                                        }
    //                                        dtrow[1] = "";
    //                                        dtrow[2] = "";
    //                                        dtrow[3] = "";
    //                                        dtAppts.Rows.Add(dtrow);
    //                                        RowsAdded++;
    //                                        Session["IsNextRowValue"] = "";
    //                                        Session["STIME"] = STime;
    //                                        Session["RowsAdded"] = RowsAdded.ToString();
    //                                    }

    //                                }
    //                                else
    //                                {
    //                                    if (IsValidRec.Equals(true))
    //                                    {
    //                                        DataRow dtrow = dtAppts.NewRow();
    //                                        if (i == 0)
    //                                        {
    //                                            dtrow[0] = tm;
    //                                        }
    //                                        else
    //                                        {

    //                                            dtrow[0] = "";
    //                                            //   tm_min = tm_min + 15;
    //                                            //   dtrow[0] = MTime.ToString() + ":" + (tm_min).ToString() + ampm;

    //                                        }

    //                                        if (!(null == Session["IsNextRowValue"]))
    //                                        {
    //                                            if (Session["IsNextRowValue"].ToString() != "")
    //                                            {
    //                                                dtrow[1] = dsAppt.Tables[0].Rows[Nextrowid][1].ToString();
    //                                                dtrow[2] = dsAppt.Tables[0].Rows[Nextrowid][2].ToString();
    //                                                dtrow[3] = dsAppt.Tables[0].Rows[Nextrowid][9].ToString();
    //                                            }
    //                                            else
    //                                            {
    //                                                dtrow[1] = dr[1].ToString();
    //                                                dtrow[2] = dr[2].ToString();
    //                                                dtrow[3] = dr[9].ToString();
    //                                            }
    //                                        }
    //                                        else
    //                                        {
    //                                            dtrow[1] = dr[1].ToString();
    //                                            dtrow[2] = dr[2].ToString();
    //                                            dtrow[3] = dr[9].ToString();
    //                                        }
    //                                        //  if (Convert.ToInt32(fromm) > range1)
    //                                        //  {
    //                                        dtAppts.Rows.Add(dtrow);
    //                                        RowsAdded++;

    //                                        Session["IsNextRowValue"] = "";
    //                                        Session["STIME"] = STime;
    //                                        Session["RowsAdded"] = RowsAdded.ToString();


    //                                        //  }
    //                                    }
    //                                }


    //                                // if (Convert.ToInt32(tomm) <= range2 && Convert.ToInt32(tomm) >= range1 && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Convert.ToInt32(fromhh) < Convert.ToInt32(STime) && Record_Count < dsAppt.Tables[0].Rows.Count)
    //                                if (Convert.ToInt32(tomm) == range2 && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Record_Count < dsAppt.Tables[0].Rows.Count)
    //                                {
    //                                    range1 = range1 + 15;
    //                                    range2 = range2 + 15;
    //                                    Session["RangeOne"] = range1.ToString();
    //                                    Session["RangeTwo"] = range2.ToString();
    //                                    i = i + 1;
    //                                    Session["Loop-Range"] = i.ToString();

    //                                    break;

    //                                }
    //                                if (Convert.ToInt32(tomm) <= range2 && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Record_Count < dsAppt.Tables[0].Rows.Count)
    //                                {
    //                                    range1 = range1 + 15;
    //                                    range2 = range2 + 15;
    //                                    Session["RangeOne"] = range1.ToString();
    //                                    Session["RangeTwo"] = range2.ToString();
    //                                    i = i + 1;
    //                                    tm_min = 0;
    //                                    Session["Loop-Range"] = i.ToString();
    //                                    break;

    //                                }

    //                                // To maintain the Overlapping appts.

    //                                //if (IsValidEntry.Equals(false))
    //                                // {
    //                                bool IsValidRange = true;
    //                                int row = 0;
    //                                int rindx = 0;
    //                                int rcnt = 0;
    //                                if (Convert.ToInt32(STime) == Convert.ToInt32(tohh))
    //                                {

    //                                    foreach (DataRow drs in dsAppt.Tables[0].Rows)
    //                                    {
    //                                        if (Convert.ToInt32(STime) == Convert.ToInt32(drs["FROMHOURS"].ToString()))
    //                                        {
    //                                            rindx = rcnt;

    //                                        }
    //                                        rcnt++;
    //                                    }

    //                                    foreach (DataRow drs in dsAppt.Tables[0].Rows)
    //                                    {
    //                                        if (row > rindx)
    //                                        {
    //                                            if (Convert.ToInt32(drs["TOHOURS"].ToString()) >= Convert.ToInt32(fromhh)
    //                                                  && Convert.ToInt32(drs["TOMINUTES"].ToString()) > Convert.ToInt32(tomm)
    //                                                && Convert.ToInt32(STime) == Convert.ToInt32(drs["TOHOURS"].ToString()) && Convert.ToInt32(tomm) > 0)
    //                                            {
    //                                                range1 = range1 + 15;
    //                                                range2 = range2 + 15;
    //                                                Session["RangeOne"] = range1.ToString();
    //                                                Session["RangeTwo"] = range2.ToString();
    //                                                i = i + 1;
    //                                                Session["Loop-Range"] = i.ToString();
    //                                                IsValidRange = false;
    //                                            }

    //                                        }
    //                                        row++;
    //                                    }
    //                                }
    //                                if (IsValidRange.Equals(false))
    //                                {
    //                                    break;
    //                                }
    //                                //    }

    //                                ////if (Convert.ToInt32(tohh) > Convert.ToInt32(STime) && Record_Count < dsAppt.Tables[0].Rows.Count)
    //                                ////{
    //                                ////    range1 = range1 + 15;
    //                                ////    range2 = range2 + 15;
    //                                ////    Session["RangeOne"] = range1.ToString();
    //                                ////    Session["RangeTwo"] = range2.ToString();
    //                                ////    i = i + 1;
    //                                ////    Session["Loop-Range"] = i.ToString();

    //                                ////    break;


    //                                ////}

    //                                if (IsValidRec.Equals(true))
    //                                // if (IsValidRec.Equals(true) && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Record_Count < dsAppt.Tables[0].Rows.Count)
    //                                {
    //                                    range1 = range1 + 15;
    //                                    range2 = range2 + 15;
    //                                }

    //                                if (RowsAdded == 3 && i == RowsAdded)
    //                                {
    //                                    i = i - 1;
    //                                }
    //                                //if (i==3 && RowsAdded < 4 && dsAppt.Tables[0].Rows.Count == Record_Count && Record_Count>1)
    //                                //{
    //                                //    i = 4 - RowsAdded;
    //                                //}



    //                            }
    //                        }



    //                    }
    //                }
    //                else
    //                {
    //                    for (int i = 0; i < 4; i++)
    //                    {

    //                        DataRow dtrow = dtAppts.NewRow();
    //                        if (i == 0)
    //                        {
    //                            dtrow[0] = tm;
    //                        }
    //                        else
    //                        {
    //                            dtrow[0] = "";
    //                            //   tm_min = tm_min + 15;
    //                            //   dtrow[0] = MTime.ToString() + ":" + (tm_min).ToString() + ampm;
    //                        }

    //                        dtrow[1] = "";
    //                        dtrow[2] = "";
    //                        dtrow[3] = "";
    //                        dtAppts.Rows.Add(dtrow);

    //                    }
    //                }

    //            }
    //            else
    //            {
    //                for (int i = 0; i < 4; i++)
    //                {

    //                    DataRow dtrow = dtAppts.NewRow();
    //                    if (i == 0)
    //                    {
    //                        dtrow[0] = tm;
    //                    }
    //                    else
    //                    {
    //                        dtrow[0] = "";
    //                        //  tm_min = tm_min + 15;
    //                        //  dtrow[0] = MTime.ToString() + ":" + (tm_min).ToString() + ampm;
    //                    }
    //                    dtrow[1] = "";
    //                    dtrow[2] = "";
    //                    dtrow[3] = "";
    //                    dtAppts.Rows.Add(dtrow);
    //                }
    //            }
    //        }


    //        if (dtAppts.Rows.Count > 0)
    //        {
    //            gvapptdet.DataSource = dtAppts;
    //            gvapptdet.DataBind();

    //        }



    //    }
    //    catch (Exception ex)
    //    {

    //    }

    //}

    //protected void lnkbtntime_Click(object sender, EventArgs e)
    //{

    //    //LinkButton lnkbtnTime = ((LinkButton)sender);


    //    //PnldispAppt.Visible = false;
    //    // Pnldispapptdet.Visible = true;

    //}
    //protected void btnback_Click(object sender, EventArgs e)
    //{
    //    Pnldispapptdet.Visible = false;
    //    PnldispAppt.Visible = true;
    //}
    //protected void gvapptdet_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName.Equals("View"))
    //    {
    //        string AptID = e.CommandArgument.ToString();
    //        if (AptID != "")
    //        {
    //            Groomer objGroomer = new Groomer();

    //            DataSet dsAptDetails = objGroomer.getAppointmentAllDetails(AptID);
    //            if (dsAptDetails.Tables.Count > 0)
    //            {
    //                if (dsAptDetails.Tables[0].Rows.Count > 0)
    //                {
    //                    lblcustnameval.Text = dsAptDetails.Tables[0].Rows[0]["CUSTOMERNAME"].ToString();
    //                    lblapptstrval.Text = dsAptDetails.Tables[0].Rows[0]["OTHERS"].ToString();

    //                    if (dsAptDetails.Tables[0].Rows[0]["EXPSTARTTIME"].ToString() != "")
    //                    {
    //                        if (dsAptDetails.Tables[0].Rows[0]["EXPSTARTTIME"].ToString().Contains(":"))
    //                        {
    //                            string[] arrstime = new string[3];
    //                            string[] arrtttime = new string[2];
    //                            arrstime = dsAptDetails.Tables[0].Rows[0]["EXPSTARTTIME"].ToString().Split(':');
    //                            arrtttime = arrstime[2].Split(' ');
    //                            lblapptexpstimeval.Text = arrstime[0].ToString() + ":" + arrstime[1].ToString() + " " + arrtttime[1].ToString();
    //                        }


    //                    }
    //                    if (dsAptDetails.Tables[0].Rows[0]["EXPENDTIME"].ToString() != "")
    //                    {
    //                        if (dsAptDetails.Tables[0].Rows[0]["EXPENDTIME"].ToString().Contains(":"))
    //                        {
    //                            string[] arrstime = new string[3];
    //                            string[] arrtttime = new string[2];
    //                            arrstime = dsAptDetails.Tables[0].Rows[0]["EXPENDTIME"].ToString().Split(':');
    //                            string min = "";
    //                            if (arrstime[1].ToString().Contains(" "))
    //                            {
    //                                arrtttime = arrstime[1].ToString().Split(' ');
    //                                min = arrtttime[0].ToString();
    //                                if (min.Length == 1)
    //                                {
    //                                    min = "0" + min;
    //                                }
    //                            }
    //                            lblapptexpetimeval.Text = arrstime[0].ToString() + ":" + min + " " + arrtttime[1].ToString();
    //                        }
    //                    }
    //                    if (dsAptDetails.Tables[0].Rows[0]["STATUS"].ToString() != "")
    //                    {
    //                        string Status = "";
    //                        if (dsAptDetails.Tables[0].Rows[0]["STATUS"].ToString().Equals("Completed"))
    //                        {
    //                            Status = "Complete";
    //                        }
    //                        else
    //                        {
    //                            Status = "InComplete";
    //                        }
    //                        lblapptstatusval.Text = Status;
    //                    }

    //                }
    //            }
    //            PnldispAppt.Visible = false;
    //            Pnldispapptdet.Visible = true;
    //        }

    //    }
    //}
    #endregion

    #region Calender Day Render
    protected void calDate_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date < DateTime.Now.Date)
        {
            //  e.Cell.BackColor = System.Drawing.Color.LightGray;
            //  e.Day.IsSelectable = false;
        }
    }
    #endregion Calender Day Render

    #region Calender Date Select Changed
    protected void calDate_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            GetAllAppointment(Convert.ToDateTime(calapptDate.SelectedDate.Date.ToString()));
        }
        catch
        {
        }
    }
    #endregion

    #region "Get All Appointment"
    protected void GetAllAppointment(DateTime dt)
    {
        #region Code
        lblsaveerror.Text = "";
        lbldtval.Text = dt.Date.ToString("dd-MMM-yyyy");
        Groomer objGroomer = new Groomer();
        PnldispAppt.Visible = true;
        Pnldispapptdet.Visible = false;
        DataTable dtAppts = new DataTable();
        dtAppts.Columns.Add("TIME");
        dtAppts.Columns.Add("ZIPCODE");
        dtAppts.Columns.Add("CNAME");
        dtAppts.Columns.Add("GroomerAppointmentId");
        int tm_min = 0;
        string Start_Index = "";
        try
        {
            // Session["STIME"] = ""; Session["RowsAdded"]=""; Session["IsNextRowValue"] = ""; Session["IsNextRowValue"] = ""; Session["RangeOne"] = ""; Session["RangeTwo"]= ""; Session["Loop-Range"] = "";
            for (int time = 6; time <= 21; time++)
            {
                #region Loop
                DataSet dsAppt = new DataSet();
                dsAppt = objGroomer.GetApptSchedules(dt.Date.ToString("yyyy-MM-dd HH:mm:ss"), time, Convert.ToInt32(Session["GId"].ToString()));
                #region AMPM
                string ampm = " AM";
                string STime = time.ToString();
                string MTime = time.ToString();
                if (time >= 12)
                {
                    ampm = " PM";
                    //      STime = (time - 12).ToString();
                    if (time != 12)
                    {
                        MTime = (time - 12).ToString();
                    }
                }

                string tm = MTime.ToString() + ":00" + ampm;
                #endregion AMPM
                if (dsAppt.Tables.Count > 0)
                {
                    #region If Appointment Exists
                    if (dsAppt.Tables[0].Rows.Count > 0)
                    {
                        int Record_Count = 0;
                        int RowsAdded = 0;
                        tm_min = 0;
                        #region Loop Check
                        foreach (DataRow dr in dsAppt.Tables[0].Rows)
                        {
                            Record_Count++;

                            tm_min = 0;
                            int fromhh = 0, fromm = 0, tohh = 0, tomm = 0;

                            if (dr["FROMHOURS"].ToString() != "" && dr["FROMMINUTES"].ToString() != "" && dr["TOHOURS"].ToString() != "" && dr["TOMINUTES"].ToString() != "")
                            {
                                fromhh = dr["FROMHOURS"].ToString() != "" ? Convert.ToInt32(dr["FROMHOURS"].ToString()) : 0;
                                fromm = dr["FROMMINUTES"].ToString() != "" ? Convert.ToInt32(dr["FROMMINUTES"].ToString()) : 0;
                                tohh = dr["TOHOURS"].ToString() != "" ? Convert.ToInt32(dr["TOHOURS"].ToString()) : 0;
                                tomm = dr["TOMINUTES"].ToString() != "" ? Convert.ToInt32(dr["TOMINUTES"].ToString()) : 0;
                            }

                            int NextFromHours = 0, NextFromMins = 0, NextToHours = 0, NextToMins = 0;
                            int Nextrowid = Record_Count;
                            if (Record_Count < dsAppt.Tables[0].Rows.Count)
                            {
                                NextFromHours = dsAppt.Tables[0].Rows[Nextrowid]["FROMHOURS"].ToString() != "" ? Convert.ToInt32(dsAppt.Tables[0].Rows[Nextrowid]["FROMHOURS"].ToString()) : 0;
                                NextFromMins = dsAppt.Tables[0].Rows[Nextrowid]["FROMMINUTES"].ToString() != "" ? Convert.ToInt32(dsAppt.Tables[0].Rows[Nextrowid]["FROMMINUTES"].ToString()) : 0;
                                NextToHours = dsAppt.Tables[0].Rows[Nextrowid]["TOHOURS"].ToString() != "" ? Convert.ToInt32(dsAppt.Tables[0].Rows[Nextrowid]["TOHOURS"].ToString()) : 0;
                                NextToMins = dsAppt.Tables[0].Rows[Nextrowid]["TOMINUTES"].ToString() != "" ? Convert.ToInt32(dsAppt.Tables[0].Rows[Nextrowid]["TOMINUTES"].ToString()) : 0;
                            }
                            #region To Manage the overlapping appointments.so the appts. can not be overlap.
                            bool IsValidEntry = true;
                            if (dsAppt.Tables[0].Rows.Count > 0 && Record_Count > 1 && Convert.ToInt32(STime) <= fromhh)
                            {
                                int rcount = 1;
                                foreach (DataRow datarows in dsAppt.Tables[0].Rows)
                                {
                                    if (rcount < Record_Count)
                                    {
                                        if (Convert.ToInt32(fromhh) == Convert.ToInt32(datarows["FROMHOURS"]) && Convert.ToInt32(fromhh) <= Convert.ToInt32(datarows["TOHOURS"])
                                        && Convert.ToInt32(fromm) >= Convert.ToInt32(datarows["FROMMINUTES"]) && Convert.ToInt32(fromm) <= 60
                                            && (Convert.ToInt32(tohh) > Convert.ToInt32(fromhh) && Convert.ToInt32(tomm) > 0 && Convert.ToInt32(fromm) > 0) && Convert.ToInt32(fromm) != 45)
                                        {
                                            IsValidEntry = false;
                                            break;
                                        }
                                    }
                                    rcount++;
                                }
                            }
                            #endregion
                            #region New Check
                            if (!(null == Session["STIME"]) && !(null == Session["RowsAdded"]))
                            {
                                int radded = Convert.ToInt32(Session["RowsAdded"]);
                                string ST = Session["STIME"].ToString();
                                if (radded == 4 && ST.Equals(STime))
                                {
                                    IsValidEntry = false;
                                }
                                Session["RowsAdded"] = null;
                                Session["STIME"] = null;
                            }
                            #endregion
                            if (IsValidEntry.Equals(false))
                            {
                                break;
                            }
                            int range1 = 0, range2 = 15;
                            #region For Loop
                            for (int i = 0; i < 4; i++)
                            {
                                Session["IsNextRowValue"] = "";
                                if (fromm >= 0)
                                {
                                    bool IsBlankRow = true;
                                    #region RangeOne
                                    if (!(null == Session["RangeOne"]) && !(null == Session["RangeTwo"]) && !(null == Session["Loop-Range"]))
                                    {
                                        if (Session["RangeOne"].ToString() != "")
                                        {
                                            range1 = Convert.ToInt32(Session["RangeOne"].ToString());
                                            Session["RangeOne"] = "";
                                        }
                                        if (Session["RangeTwo"].ToString() != "")
                                        {
                                            range2 = Convert.ToInt32(Session["RangeTwo"].ToString());
                                            Session["RangeTwo"] = "";
                                        }
                                        if (Session["Loop-Range"].ToString() != "")
                                        {
                                            i = Convert.ToInt32(Session["Loop-Range"].ToString());
                                            Session["Loop-Range"] = "";
                                        }
                                    }

                                    int counter = Record_Count;
                                    #endregion
                                    #region While Loop
                                    //int counter = Record_Count + 1;
                                    while (counter < dsAppt.Tables[0].Rows.Count)
                                    {
                                        string NextFHours = dsAppt.Tables[0].Rows[counter]["FROMHOURS"].ToString();
                                        string NextFMins = dsAppt.Tables[0].Rows[counter]["FROMMINUTES"].ToString();
                                        string NextTHours = dsAppt.Tables[0].Rows[counter]["TOHOURS"].ToString();
                                        string NextTMins = dsAppt.Tables[0].Rows[counter]["TOMINUTES"].ToString();

                                        if ((Convert.ToInt32(NextFMins) >= range1 && Convert.ToInt32(NextFMins) < range2 && NextFHours.Equals(fromhh) && NextTHours.Equals(fromhh)))
                                        //|| (Convert.ToInt32(NextFMins) == 0 && Convert.ToInt32(NextFMins) < Convert.ToInt32(fromm) && Convert.ToInt32(NextTMins) == 0 && NextFHours.Equals(fromhh) && Convert.ToInt32(NextTHours) > Convert.ToInt32(fromhh)))
                                        //if ((Convert.ToInt32(NextFMins) >= range1 && Convert.ToInt32(NextFMins) <= range2 && NextFHours.Equals(fromhh) && Convert.ToInt32(NextFMins) < Convert.ToInt32(fromm) && (!(fromm.Equals("0"))))
                                        //  || (Convert.ToInt32(NextFMins) >= range1 && Convert.ToInt32(NextFMins) <= range2 && NextFHours.Equals(fromhh) && (Convert.ToInt32(NextFMins) < Convert.ToInt32(tomm)) && (Convert.ToInt32(NextToMins) < Convert.ToInt32(tomm))))
                                        //if (NextFHours.Equals(fromhh) && (Convert.ToInt32(NextFMins) < Convert.ToInt32(fromm) || Convert.ToInt32(NextFMins)< Convert.ToInt32(tomm)) && Convert.ToInt32(NextTHours) > Convert.ToInt32(NextFHours) && range1 < Convert.ToInt32(fromm))
                                        {
                                            IsBlankRow = false;
                                            Session["IsNextRowValue"] = "1";
                                            break;
                                        }
                                        counter++;
                                    }
                                    #endregion
                                    #region Commented Code
                                    //if (NextFromHours.Equals(fromhh) && Convert.ToInt32(NextFromMins) < Convert.ToInt32(fromm) && Convert.ToInt32(NextToHours) > Convert.ToInt32(NextFromHours) && range1 < Convert.ToInt32(fromm))
                                    //{
                                    //    IsBlankRow = false;
                                    //    Session["IsNextRowValue"] = "1";
                                    //}
                                    //if ((Convert.ToInt32(fromm) >= range1 && Convert.ToInt32(fromm) < range2 && Convert.ToInt32(fromhh) == Convert.ToInt32(STime)) || (Convert.ToInt32(fromm) <= range1 &&  range2==60 && Convert.ToInt32(fromhh) == Convert.ToInt32(STime)) || (Convert.ToInt32(fromhh) <= Convert.ToInt32(STime) && Convert.ToInt32(tomm) > range1 && Convert.ToInt32(tohh) == Convert.ToInt32(STime)))
                                    if ((Convert.ToInt32(fromm) < range2 && Convert.ToInt32(fromhh) == Convert.ToInt32(STime)) || (Convert.ToInt32(fromm) <= range1 && range2 <= 60 && Convert.ToInt32(fromhh) == Convert.ToInt32(STime)))
                                    {
                                        IsBlankRow = false;
                                    }
                                    bool IsValidRec = true;
                                    if ((Convert.ToInt32(fromhh) != Convert.ToInt32(STime) && Convert.ToInt32(tohh) != Convert.ToInt32(STime))
                                        || (Convert.ToInt32(tohh) == Convert.ToInt32(STime) && tomm.Equals("0")))
                                    //                                        || (Convert.ToInt32(tohh) > Convert.ToInt32(fromhh) && Record_Count <= dsAppt.Tables[0].Rows.Count)
                                    {
                                        IsValidRec = false;
                                    }
                                    //if(Convert.ToInt32(fromhh) != Convert.ToInt32(STime) && Convert.ToInt32(STime)<=Convert.ToInt32(tohh))
                                    //{
                                    //    IsValidRec = true;
                                    //}
                                    //if ((Convert.ToInt32(fromhh) <= Convert.ToInt32(STime) && Convert.ToInt32(tomm) > range1 && Convert.ToInt32(tohh) == Convert.ToInt32(STime)))
                                    if ((Convert.ToInt32(fromhh) <= Convert.ToInt32(STime) && Convert.ToInt32(tomm) > range1 && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && range1 > Convert.ToInt32(fromm)) || (Convert.ToInt32(fromhh) <= Convert.ToInt32(STime) && Convert.ToInt32(tomm) > range1 && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Convert.ToInt32(fromhh) != Convert.ToInt32(tohh)))
                                    {
                                        IsBlankRow = false;
                                    }
                                    #endregion
                                    #region "Next"
                                    bool IsNextr = false;
                                    if (!(null == Session["IsNextRowValue"]))
                                    {
                                        if (Session["IsNextRowValue"].ToString().Equals("1"))
                                        {
                                            IsNextr = true;
                                        }
                                    }
                                    // ex. 8:15 PM to 8:30 PM or 8:45 PM to 9:30 PM
                                    //if (Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Convert.ToInt32(fromm) > range1)
                                    if (Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Convert.ToInt32(fromm) > range1 && Convert.ToInt32(fromm) > range2 && IsNextr.Equals(false))
                                    {
                                        IsBlankRow = true;
                                    }

                                    if ((Convert.ToInt32(fromhh) < Convert.ToInt32(STime) && Convert.ToInt32(tohh) > Convert.ToInt32(STime)))
                                    {
                                        IsBlankRow = false;
                                        IsValidRec = true;
                                    }
                                    // for ex. 6:00 to 6:30
                                    //&& Convert.ToInt32(fromm) != range2
                                    if ((Convert.ToInt32(tomm) <= range1 && IsNextr.Equals(false) || Convert.ToInt32(fromm) > range2) && Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && IsNextr.Equals(false))
                                    //original  if (Convert.ToInt32(tomm) < range1 && Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Convert.ToInt32(tohh) == Convert.ToInt32(STime))
                                    //  if (Convert.ToInt32(fromm) > range2 && Convert.ToInt32(tomm) < range2 && Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Convert.ToInt32(tohh) == Convert.ToInt32(STime))
                                    {
                                        IsBlankRow = true;
                                    }
                                    //if (STime.Equals("4") && IsValidRec.Equals(true))
                                    //{
                                    //    int a = 0;
                                    //}
                                    if (i <= 3 && IsValidRec.Equals(false) && dsAppt.Tables[0].Rows.Count == Record_Count)
                                    {
                                        IsValidRec = true;
                                    }
                                    //if (dsAppt.Tables[0].Rows.Count > 0 && Record_Count > 0)
                                    //{
                                    //    int rcount = 0;
                                    //    foreach (DataRow datarows in dsAppt.Tables[0].Rows)
                                    //    {
                                    //        if (rcount != Record_Count)
                                    //        {
                                    //            if (Convert.ToInt32(fromhh) >= Convert.ToInt32(datarows["FROMHOURS"]) && Convert.ToInt32(fromhh) <= Convert.ToInt32(datarows["TOHOURS"])
                                    //            && Convert.ToInt32(fromm) >= Convert.ToInt32(datarows["FROMMINUTES"]) && Convert.ToInt32(fromm) <= Convert.ToInt32(datarows["TOMINUTES"])
                                    //              )
                                    //            {
                                    //                IsValidRec = false;
                                    //            }
                                    //        }
                                    //        rcount++;
                                    //    }
                                    //}
                                    #endregion
                                    #region "Read Count"
                                    if (Record_Count < dsAppt.Tables[0].Rows.Count)
                                    {
                                        if ((Convert.ToInt32(NextFromHours) == Convert.ToInt32(fromhh) && Convert.ToInt32(NextFromMins) == 45
                              && Convert.ToInt32(NextToHours) == Convert.ToInt32(fromhh) + 1 &&
                                Convert.ToInt32(NextToMins) == 0 && range1 >= 45) || (Convert.ToInt32(NextFromHours) == Convert.ToInt32(fromhh)
                                            && range1 >= Convert.ToInt32(NextFromMins) && Convert.ToInt32(NextToHours) == Convert.ToInt32(fromhh)
                                            && Convert.ToInt32(NextFromMins) > 0))
                                        {
                                            IsValidRec = false;
                                            Session["RangeOne"] = range1.ToString();
                                            Session["RangeTwo"] = range2.ToString();
                                            i = i + 1;
                                            Session["Loop-Range"] = i.ToString();
                                            break;
                                        }
                                    }
                                    #endregion
                                    #region Blank Row Check
                                    if (IsBlankRow.Equals(true))
                                    {
                                        if (IsValidRec.Equals(true))
                                        {
                                            DataRow dtrow = dtAppts.NewRow();
                                            if (i == 0)
                                            {
                                                dtrow[0] = tm;
                                                //Start_Index = i;
                                                Start_Index = tm;
                                            }
                                            else
                                            {
                                                // dtrow[0] = "";
                                                tm_min = tm_min + 15;
                                                dtrow[0] = MTime.ToString() + ":" + (tm_min).ToString() + ampm;
                                            }
                                            dtrow[1] = "";
                                            dtrow[2] = "";
                                            dtrow[3] = "";
                                            dtAppts.Rows.Add(dtrow);
                                            RowsAdded++;
                                            Session["IsNextRowValue"] = "";
                                            Session["STIME"] = STime;
                                            Session["RowsAdded"] = RowsAdded.ToString();
                                        }
                                    }
                                    #endregion Blank Row Check
                                    #region If notBlank Row Check
                                    else
                                    {
                                        if (IsValidRec.Equals(true))
                                        {
                                            DataRow dtrow = dtAppts.NewRow();
                                            if (i == 0)
                                            {
                                                dtrow[0] = tm;
                                            }
                                            else
                                            {
                                                //dtrow[0] = "";
                                                tm_min = tm_min + 15;
                                                dtrow[0] = MTime.ToString() + ":" + (tm_min).ToString() + ampm;
                                            }
                                            if (!(null == Session["IsNextRowValue"]))
                                            {
                                                if (Session["IsNextRowValue"].ToString() != "")
                                                {
                                                    dtrow[1] = dsAppt.Tables[0].Rows[Nextrowid][1].ToString();
                                                    dtrow[2] = dsAppt.Tables[0].Rows[Nextrowid][2].ToString();
                                                    dtrow[3] = dsAppt.Tables[0].Rows[Nextrowid][9].ToString();
                                                }
                                                else
                                                {
                                                    dtrow[1] = dr[1].ToString();
                                                    dtrow[2] = dr[2].ToString();
                                                    dtrow[3] = dr[9].ToString();
                                                }
                                            }
                                            else
                                            {
                                                dtrow[1] = dr[1].ToString();
                                                dtrow[2] = dr[2].ToString();
                                                dtrow[3] = dr[9].ToString();
                                            }
                                            //  if (Convert.ToInt32(fromm) > range1)
                                            //  {
                                            dtAppts.Rows.Add(dtrow);
                                            RowsAdded++;

                                            Session["IsNextRowValue"] = "";
                                            Session["STIME"] = STime;
                                            Session["RowsAdded"] = RowsAdded.ToString();
                                            //  }
                                        }
                                    }
                                    #endregion If notBlank Row Check
                                    #region tomm
                                    // if (Convert.ToInt32(tomm) <= range2 && Convert.ToInt32(tomm) >= range1 && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Convert.ToInt32(fromhh) < Convert.ToInt32(STime) && Record_Count < dsAppt.Tables[0].Rows.Count)
                                    if (Convert.ToInt32(tomm) == range2 && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Record_Count < dsAppt.Tables[0].Rows.Count)
                                    {
                                        range1 = range1 + 15;
                                        range2 = range2 + 15;
                                        Session["RangeOne"] = range1.ToString();
                                        Session["RangeTwo"] = range2.ToString();
                                        i = i + 1;
                                        Session["Loop-Range"] = i.ToString();
                                        break;
                                    }
                                    if (Convert.ToInt32(tomm) <= range2 && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Record_Count < dsAppt.Tables[0].Rows.Count)
                                    {
                                        range1 = range1 + 15;
                                        range2 = range2 + 15;
                                        Session["RangeOne"] = range1.ToString();
                                        Session["RangeTwo"] = range2.ToString();
                                        i = i + 1;
                                        tm_min = 0;
                                        Session["Loop-Range"] = i.ToString();
                                        break;
                                    }
                                    #endregion tomm
                                    #region To maintain the Overlapping appts.
                                    //if (IsValidEntry.Equals(false))
                                    // {
                                    bool IsValidRange = true;
                                    int row = 0;
                                    int rindx = 0;
                                    int rcnt = 0;
                                    if (Convert.ToInt32(STime) == Convert.ToInt32(tohh))
                                    {
                                        foreach (DataRow drs in dsAppt.Tables[0].Rows)
                                        {
                                            if (Convert.ToInt32(STime) == Convert.ToInt32(drs["FROMHOURS"].ToString()))
                                            {
                                                rindx = rcnt;
                                            }
                                            rcnt++;
                                        }
                                        foreach (DataRow drs in dsAppt.Tables[0].Rows)
                                        {
                                            if (row > rindx)
                                            {
                                                if (Convert.ToInt32(drs["TOHOURS"].ToString()) >= Convert.ToInt32(fromhh)
                                                      && Convert.ToInt32(drs["TOMINUTES"].ToString()) > Convert.ToInt32(tomm)
                                                    && Convert.ToInt32(STime) == Convert.ToInt32(drs["TOHOURS"].ToString()) && Convert.ToInt32(tomm) > 0)
                                                {
                                                    range1 = range1 + 15;
                                                    range2 = range2 + 15;
                                                    Session["RangeOne"] = range1.ToString();
                                                    Session["RangeTwo"] = range2.ToString();
                                                    i = i + 1;
                                                    Session["Loop-Range"] = i.ToString();
                                                    IsValidRange = false;
                                                }
                                            }
                                            row++;
                                        }
                                    }
                                    #endregion
                                    #region IsValidRange
                                    if (IsValidRange.Equals(false))
                                    {
                                        break;
                                    }
                                    //    }
                                    ////if (Convert.ToInt32(tohh) > Convert.ToInt32(STime) && Record_Count < dsAppt.Tables[0].Rows.Count)
                                    ////{
                                    ////    range1 = range1 + 15;
                                    ////    range2 = range2 + 15;
                                    ////    Session["RangeOne"] = range1.ToString();
                                    ////    Session["RangeTwo"] = range2.ToString();
                                    ////    i = i + 1;
                                    ////    Session["Loop-Range"] = i.ToString();
                                    ////    break;
                                    ////}
                                    if (IsValidRec.Equals(true))
                                    // if (IsValidRec.Equals(true) && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Record_Count < dsAppt.Tables[0].Rows.Count)
                                    {
                                        range1 = range1 + 15;
                                        range2 = range2 + 15;
                                    }
                                    if (RowsAdded == 3 && i == RowsAdded)
                                    {
                                        i = i - 1;
                                    }
                                    //if (i==3 && RowsAdded < 4 && dsAppt.Tables[0].Rows.Count == Record_Count && Record_Count>1)
                                    //{
                                    //    i = 4 - RowsAdded;
                                    //}
                                    #endregion
                                }
                            }
                            #endregion For Loop
                        }
                        #endregion Loop Check
                    }
                    #endregion If Appointment Exists
                    #region If No any Appointment Exists
                    else
                    {
                        int tmin = 0;
                        for (int i = 0; i < 4; i++)
                        {

                            DataRow dtrow = dtAppts.NewRow();
                            if (i == 0)
                            {
                                dtrow[0] = tm;
                            }
                            else
                            {
                                tmin = tmin + 15;
                                dtrow[0] = MTime.ToString() + ":" + (tmin).ToString() + ampm;

                            }

                            dtrow[1] = "";
                            dtrow[2] = "";
                            dtrow[3] = "";
                            dtAppts.Rows.Add(dtrow);
                        }
                    }
                    #endregion If No any Appointment Exists
                }
                else
                {
                    #region No Any Appointment For the Date
                    for (int i = 0; i < 4; i++)
                    {
                        DataRow dtrow = dtAppts.NewRow();
                        if (i == 0)
                        {
                            dtrow[0] = tm;
                        }
                        else
                        {
                            //dtrow[0] = "";
                            tm_min = tm_min + 15;
                            dtrow[0] = MTime.ToString() + ":" + (tm_min).ToString() + ampm;
                        }
                        dtrow[1] = "";
                        dtrow[2] = "";
                        dtrow[3] = "";
                        dtAppts.Rows.Add(dtrow);
                    }
                    #endregion No Any Appointment For the Date
                }
                #endregion
            }
        }
        catch (Exception ex) { throw ex; }
        if (dtAppts.Rows.Count > 0)
        {
            gvapptdet.DataSource = dtAppts;
            gvapptdet.DataBind();
        }
        #endregion
        ClearSession();
    }
    #endregion

    #region Free All Session
    protected void ClearSession()
    {
        Session.Remove("STIME");
        Session.Remove("RowsAdded");
        Session.Remove("IsNextRowValue");
        Session.Remove("RangeOne");
        Session.Remove("RangeTwo");
        Session.Remove("Loop-Range");
        Session.Remove("RowsAdded");
    }
    #endregion

    #region GridView Event
    protected void lnkbtntime_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtnTime = ((LinkButton)sender);
        //PnldispAppt.Visible = false;
        // Pnldispapptdet.Visible = true;

        //if (lblStart.Text=="")
        //{
        //    lblStart.Text = lnkbtnTime.Text;
        //}
        //else if (lblEnd.Text=="")
        //{
        //    lblEnd.Text = lnkbtnTime.Text;
        //}
        //if (lblStart.Text != "")
        //{
        //    lblStart.Text = lnkbtnTime.Text;
        //}
        //else if (lblEnd.Text != "")
        //{
        //    lblEnd.Text = lnkbtnTime.Text;
        //}
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        Pnldispapptdet.Visible = false;
        PnldispAppt.Visible = true;

        if (!(null == Session["PageFrom"]))
        {
            string chk = Session["PageFrom"].ToString();
            if (chk == "OP" || chk == "OPR")
            {
                pnlRebook.Visible = true;
            }
        }
    }
    protected void gvapptdet_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("View"))
        {
            string AptID = e.CommandArgument.ToString();

            if (AptID != "")
            {
                Groomer objGroomer = new Groomer();

                DataSet dsAptDetails = objGroomer.getAppointmentAllDetails(AptID);
                if (dsAptDetails.Tables.Count > 0)
                {
                    if (dsAptDetails.Tables[0].Rows.Count > 0)
                    {
                        lblcustnameval.Text = dsAptDetails.Tables[0].Rows[0]["CUSTOMERNAME"].ToString();
                        lblapptstrval.Text = dsAptDetails.Tables[0].Rows[0]["OTHERS"].ToString();
                        lblapptexpstimeval.Text = dsAptDetails.Tables[0].Rows[0]["EXPSTARTTIME"].ToString();
                        lblapptexpetimeval.Text = dsAptDetails.Tables[0].Rows[0]["EXPENDTIME"].ToString();
                        lblapptstatusval.Text = dsAptDetails.Tables[0].Rows[0]["STATUS"].ToString().ToLower().Equals("completed") ? "Complete" : "Incomplete";
                        #region Commented By Umesh
                        //if (dsAptDetails.Tables[0].Rows[0]["EXPSTARTTIME"].ToString() != "")
                        //{
                        //    if (dsAptDetails.Tables[0].Rows[0]["EXPSTARTTIME"].ToString().Contains(":"))
                        //    {
                        //        string[] arrstime = new string[3];
                        //        string[] arrtttime = new string[2];
                        //        arrstime = dsAptDetails.Tables[0].Rows[0]["EXPSTARTTIME"].ToString().Split(':');
                        //        if (arrstime.Length > 2)
                        //        {
                        //            arrtttime = arrstime[2].Split(' ');
                        //        }
                        //        else
                        //        {
                        //            arrtttime = arrstime[1].Split(' ');
                        //        }
                        //        lblapptexpstimeval.Text = arrstime[0].ToString() + ":" + arrstime[1].ToString() + " " + arrtttime[1].ToString();
                        //    }
                        //}
                        //if (dsAptDetails.Tables[0].Rows[0]["EXPENDTIME"].ToString() != "")
                        //{
                        //    if (dsAptDetails.Tables[0].Rows[0]["EXPENDTIME"].ToString().Contains(":"))
                        //    {
                        //        string[] arrstime = new string[3];
                        //        string[] arrtttime = new string[2];
                        //        arrstime = dsAptDetails.Tables[0].Rows[0]["EXPENDTIME"].ToString().Split(':');
                        //        string min = "";
                        //        if (arrstime[1].ToString().Contains(" "))
                        //        {
                        //            arrtttime = arrstime[1].ToString().Split(' ');
                        //            min = arrtttime[0].ToString();
                        //            if (min.Length == 1)
                        //            {
                        //                min = "0" + min;
                        //            }
                        //        }
                        //        lblapptexpetimeval.Text = arrstime[0].ToString() + ":" + min + " " + arrtttime[1].ToString();
                        //    }
                        //}

                        //if (dsAptDetails.Tables[0].Rows[0]["STATUS"].ToString() != "")
                        //{
                        //    string Status = "";
                        //    if (dsAptDetails.Tables[0].Rows[0]["STATUS"].ToString().Equals("Completed"))
                        //    {
                        //        Status = "Complete";
                        //    }
                        //    else
                        //    {
                        //        Status = "InComplete";
                        //    }
                        //    lblapptstatusval.Text = Status;
                        //}
                        #endregion Commented By Umesh
                    }
                }
                lblStart.Text = "";
                lblEnd.Text = "";
                PnldispAppt.Visible = false;
                Pnldispapptdet.Visible = true;
                pnlRebook.Visible = false;
            }
            else
            {
                LinkButton lnkButton = (LinkButton)e.CommandSource;
                if (pnlRebook.Visible == true)
                {
                    if (!(null == Session["t"]))
                    {
                        if ("Yes" == Convert.ToString(Session["t"]))
                        {
                            lblEnd.Text = lnkButton.Text;
                        }
                        else
                        {
                            lblEnd.Text = "";
                        }
                    }
                    if (lblStart.Text == "")
                    {
                        lblStart.Text = lnkButton.Text;
                        Session["t"] = "Yes";
                    }
                }
            }
        }
    }

    #endregion

    #region "Reset"
    protected void btnReset_Click(object sender, EventArgs e)
    {
        lblStart.Text = "";
        lblEnd.Text = "";
        Session["t"] = "";
    }
    #endregion



    #region "Save"
    protected void btnSchedule_Click(object sender, EventArgs e)
    {
        if (lbldtval.Text != "" && lblStart.Text != "" && lblEnd.Text != "")
        {
            if (calapptDate.SelectedDate > DateTime.Today)
            {
                DateTime st = Convert.ToDateTime(lblStart.Text);
                TimeSpan t1 = st.TimeOfDay;

                DateTime et = Convert.ToDateTime(lblEnd.Text);
                TimeSpan t2 = et.TimeOfDay;

                int result = TimeSpan.Compare(t2, t1);
                // Get the Expected time difference
                double difference = t2.TotalHours - t1.TotalHours;
                decimal ExpTime = Convert.ToDecimal(difference);

                if (result == 1)
                {
                    if (!(null == Session["GroomerAppointmentId"]))
                    {
                        if (!(null == Session["PageFrom"]))
                        {
                            #region Reebok From Calender
                            if ("OPR" == Session["PageFrom"].ToString())
                            {
                                Session["NextDate"] = calapptDate.SelectedDate.ToShortDateString();
                                Session["NextStartTime"] = objGroomer.Time24Formatter(lblStart.Text);
                                Session["NextEndTime"] = objGroomer.Time24Formatter(lblEnd.Text);
                                string s = lblStart.Text.Substring(0, 2);
                                // Resend Rebook details back to Operation Log page.
                                Session["rdoRebookD"] = "Yes";
                                Session["PageFrom"] = "OPR";
                                Response.Redirect("Operations.aspx");
                            }
                            #endregion

                            #region ReSchedule Next Appointment
                            else
                            {
                                int aid = Convert.ToInt32(Session["NextGroomerAppointmentId"]);
                               
                                Groomer obj = new Groomer();
                                string m = calapptDate.SelectedDate.Month.ToString();
                                string d = calapptDate.SelectedDate.Date.Day.ToString();
                                string s = lblStart.Text.Substring(0, 2);
                                // Splited Start Time
                                string[] newstart = lblStart.Text.Split(' ');
                                string[] newstart1 = newstart[0].Split(':');
                                string newstart2 = newstart1[0].ToString() + newstart1[1].ToString();

                                string[] newend = lblEnd.Text.Split(' ');
                                string[] newend1 = newend[0].Split(':');
                                string newend2 = newstart1[0].ToString() + newend1[1].ToString();
                                // Created datetimeformat for appointment
                                string datetimeformat = m + d + "." + newstart2 + "-" + newend2;
                                // Updated Groomer next appointment Date, Start Time, End Time, expected time 
                                obj.UpdateNextGroomerAppointment(aid, calapptDate.SelectedDate.ToString(), lblStart.Text, lblEnd.Text, datetimeformat, ExpTime);
                                Session["pettime"] = ExpTime;
                                Session["PageFrom"] = "ORS";
                                Response.Redirect("Operations.aspx");
                            }
                            #endregion
                        }
                        else
                        {
                        }
                    }
                }
                else
                {
                    lblsaveerror.Text = "Please select differnt End Time.";
                    lblEnd.Text = "";
                }
            }
            else
            {
                lbldtval.Text = String.Empty; lblStart.Text = String.Empty; lblEnd.Text = String.Empty;
                lblsaveerror.Text = "Please select future date only to schedule appointment";
            }
        }
        else
        {
            lbldtval.Text = String.Empty; lblStart.Text = String.Empty; lblEnd.Text = String.Empty;
            lblsaveerror.Text = "Please select Appointment date ,Start Time and End Time";
        }
    }
    #endregion

    #region "Back"
    protected void btnBacklogpage_Click(object sender, EventArgs e)
    {
        Session["rdoRebookD"] = "";
        Session["PageFrom"] = "OPR";
        Response.Redirect("Operations.aspx");
    }
    #endregion
}
