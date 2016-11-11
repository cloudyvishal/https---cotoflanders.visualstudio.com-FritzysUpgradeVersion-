using System.Web.UI.WebControls;

namespace advancewebtosolution.BO
{
    public interface ILogicSQLDMO
    {
        void dIsplayServerList(DropDownList dropDownListName);
        void dIsplayDatabases(DropDownList cboDatabase, InfoSQLDMO.informationLayer info);
        void addSQLScriptToDataBase(InfoSQLDMO.informationLayer info);
        void cReateSQLDatabaseBackup(InfoSQLDMO.informationLayer InSQLDMO);
        void cReateSqlDatabseRestore(InfoSQLDMO.informationLayer InSQLDMO);
        void zIpDatabseFile(string srcPath, string destPath);
        void uNzIpDatabaseFile(string SrcPath, string DestPath);
    }
}
