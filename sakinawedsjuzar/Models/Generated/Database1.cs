



















// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `DefaultConnection`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=.;Initial Catalog=WeddingDB;Persist Security Info=True;User ID=sa;Password=danat123$`
//     Schema:                 ``
//     Include Views:          `False`



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace sakinawedsjuzar
{

	public partial class DefaultConnectionDB : Database
	{
		public DefaultConnectionDB() 
			: base("DefaultConnection")
		{
			CommonConstruct();
		}

		public DefaultConnectionDB(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			DefaultConnectionDB GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static DefaultConnectionDB GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new DefaultConnectionDB();
        }

		[ThreadStatic] static DefaultConnectionDB _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        

		public class Record<T> where T:new()
		{
			public static DefaultConnectionDB repo { get { return DefaultConnectionDB.GetInstance(); } }
			public bool IsNew() { return repo.IsNew(this); }
			public object Insert() { return repo.Insert(this); }

			public void Save() { repo.Save(this); }
			public int Update() { return repo.Update(this); }

			public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
			public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
			public static int Update(Sql sql) { return repo.Update<T>(sql); }
			public int Delete() { return repo.Delete(this); }
			public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
			public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
			public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
			public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
			public static bool Exists(string sql, params object[] args) { return repo.Exists<T>(sql, args); }
			public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
			public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
			public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
			public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
			public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
			public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
			public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
			public static T Single(Sql sql) { return repo.Single<T>(sql); }
			public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
			public static T First(Sql sql) { return repo.First<T>(sql); }
			public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
			public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }
			public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }
			public static List<T> Fetch(long page, long itemsPerPage, Sql sql) { return repo.Fetch<T>(page, itemsPerPage, sql); }
			public static List<T> SkipTake(long skip, long take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
			public static List<T> SkipTake(long skip, long take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
			public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
			public static Page<T> Page(long page, long itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
			public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
			public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }

		}

	}
	



    

	[TableName("dbo.Section")]



	[PrimaryKey("SectionID")]



	[ExplicitColumns]
    public partial class Section : DefaultConnectionDB.Record<Section>  
    {



		[Column] public int SectionID { get; set; }





		[Column] public string Name { get; set; }



	}

    

	[TableName("dbo.EntityImages")]



	[PrimaryKey("EntityImageID")]



	[ExplicitColumns]
    public partial class EntityImage : DefaultConnectionDB.Record<EntityImage>  
    {



		[Column] public int EntityImageID { get; set; }





		[Column] public int? SectionID { get; set; }





		[Column] public string Url { get; set; }





		[Column] public string thumbnail { get; set; }





		[Column] public int? EntityID { get; set; }





		[Column] public int? SequenceNo { get; set; }





		[Column] public string Name { get; set; }



	}

    

	[TableName("dbo.CommonInfo")]



	[PrimaryKey("CommonInfoID")]



	[ExplicitColumns]
    public partial class CommonInfo : DefaultConnectionDB.Record<CommonInfo>  
    {



		[Column] public int CommonInfoID { get; set; }





		[Column] public DateTime? WeddingDate { get; set; }





		[Column] public string CouplePictureUrl { get; set; }





		[Column] public string CoupleInfo { get; set; }





		[Column] public string BrideFullName { get; set; }





		[Column] public string GroomFullName { get; set; }





		[Column] public string GiftRegistryContent { get; set; }





		[Column] public string Address { get; set; }





		[Column] public string ContactInfo { get; set; }





		[Column] public int? GuestCount { get; set; }





		[Column] public int? AttendCount { get; set; }





		[Column] public int? BridesmaidCount { get; set; }





		[Column] public int? GroomsmenCount { get; set; }





		[Column] public string AboutUs { get; set; }





		[Column] public string BridemaidsContent { get; set; }





		[Column] public string GroomsmenContent { get; set; }





		[Column] public string GiftRegistryImageUrl { get; set; }





		[Column] public string GoogleMapAddress { get; set; }



	}

    

	[TableName("dbo.ContactUs")]



	[ExplicitColumns]
    public partial class ContactU : DefaultConnectionDB.Record<ContactU>  
    {



		[Column] public string Name { get; set; }





		[Column] public string EmailID { get; set; }





		[Column] public int? PhoneNo { get; set; }





		[Column] public string Msg { get; set; }



	}

    

	[TableName("dbo.Comments")]



	[PrimaryKey("CommentID")]



	[ExplicitColumns]
    public partial class Comment : DefaultConnectionDB.Record<Comment>  
    {



		[Column] public int CommentID { get; set; }





		[Column] public int? ParentCommentID { get; set; }





		[Column] public string UserName { get; set; }





		[Column] public string Content { get; set; }





		[Column] public string ProfileImageUrl { get; set; }



	}

    

	[TableName("dbo.OurLoveStory")]



	[PrimaryKey("OurStoryID")]



	[ExplicitColumns]
    public partial class OurLoveStory : DefaultConnectionDB.Record<OurLoveStory>  
    {



		[Column] public int OurStoryID { get; set; }





		[Column] public string Title1 { get; set; }





		[Column] public string Title2 { get; set; }





		[Column] public string PublishDate { get; set; }





		[Column] public string Content { get; set; }





		[Column] public string SpecialComment { get; set; }





		[Column] public string CommentBy { get; set; }





		[Column] public int? TemplateId { get; set; }



	}

    

	[TableName("dbo.OurEvents")]



	[PrimaryKey("OurEventID")]



	[ExplicitColumns]
    public partial class OurEvent : DefaultConnectionDB.Record<OurEvent>  
    {



		[Column] public int OurEventID { get; set; }





		[Column] public string Title { get; set; }





		[Column] public string EventLocation { get; set; }





		[Column] public string EventContent { get; set; }





		[Column] public int? TemplateID { get; set; }



	}


}



