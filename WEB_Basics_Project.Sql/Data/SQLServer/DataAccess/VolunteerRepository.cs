namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public class VolunteerRepository
    {
        private readonly IDbSettings _settings;

        public VolunteerRepository(IDbSettings settings)
            => this._settings = settings;



    }
}