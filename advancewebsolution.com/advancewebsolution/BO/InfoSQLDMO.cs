namespace InfoSQLDMO
{
    public class informationLayer
    {
        #region " Declarations "
        string _strServerName;
        string _strLoginName;
        string _strPwd;
        string _strdbName;
        string _scriptFilePath;
        string _FileName;
        string _strmyDocPath;
        string _zipFileName;
        string _bkpFileName;
        string _ErrorMessageDataLayer;

        #endregion

        #region " Functions "

        public string zipFileName
        {
            get { return _zipFileName; }
            set { _zipFileName = value; }
        }

        public string bkpFileName
        {
            get { return _bkpFileName; }
            set { _bkpFileName = value; }
        }
        public string strmyDocPath
        {
            get { return _strmyDocPath; }
            set { _strmyDocPath = value; }
        }
        public string strServerName
        {
            get { return _strServerName; }
            set { _strServerName = value; }
        }
        public string strLoginName
        {
            get { return _strLoginName; }
            set { _strLoginName = value; }
        }
        public string strPwd
        {
            get { return _strPwd; }
            set { _strPwd = value; }
        }
        public string strdbName
        {
            get { return _strdbName; }
            set { _strdbName = value; }
        }
        public string scriptFilePath
        {
            get { return _scriptFilePath; }
            set { _scriptFilePath = value; }
        }
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }
        public string ErrorMessageDataLayer
        {
            get { return _ErrorMessageDataLayer; }
            set { _ErrorMessageDataLayer = value; }
        }
        #endregion
    }
}