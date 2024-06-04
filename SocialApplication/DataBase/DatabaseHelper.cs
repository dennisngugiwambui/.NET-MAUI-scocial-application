using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;
using SQLite;
using static SocialApplication.SignUp;

namespace SocialApplication.DataBase
{
	public class DatabaseHelper
	{
		SQLiteAsyncConnection Database;

		public DatabaseHelper()
		{
		}

		async Task Init()
		{
			if (Database is not null)
				return;

			Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
			var result = await Database.CreateTableAsync<UserLogin>();
			//var records = await Database.CreateTableAsync<CourseRecord>();
			//var assesment = await Database.CreateTableAsync<AssessmentRecord>();
		}



		public async Task<List<TermRecord>> GetItemsAsync()
		{
			await Init();
			return await Database.Table<TermRecord>().ToListAsync();
		}

		public async Task<List<CourseRecord>> GetRecordAsync()
		{
			await Init();
			return await Database.Table<CourseRecord>().ToListAsync();
		}
		public async Task<List<AssessmentRecord>> GetAssessmentsAsync()
		{
			await Init();
			return await Database.Table<AssessmentRecord>().ToListAsync();
		}

		// public async Task<List<InstructorRecord>> GetInstructorAsync()
		// {
		//     await Init();
		//      return await Database.Table<InstructorRecord>().ToListAsync();
		//  }


		//Getting the Items

		public async Task<TermRecord> GetItemAsync(int id)
		{
			await Init();
			return await Database.Table<TermRecord>().Where(i => i.termId == id).FirstOrDefaultAsync();
		}

		public async Task<CourseRecord> GetRecordAsync(int id)
		{
			await Init();
			return await Database.Table<CourseRecord>().Where(i => i.courseId == id).FirstOrDefaultAsync();
		}

		public async Task<AssessmentRecord> GetAssessmentAsync(int id)
		{
			await Init();
			return await Database.Table<AssessmentRecord>().Where(i => i.assessmentId == id).FirstOrDefaultAsync();
		}

		//public async Task<InstructorRecord> GetInstructorAsync(int id)
		//{
		//    await Init();
		//     return await Database.Table<InstructorRecord>().Where(i => i.instructorId == id).FirstOrDefaultAsync();
		// }




		//Saving the items now
		public async Task<int> SaveItemAsync(TermRecord item)
		{
			await Init();
			if (item.termId != 0)
				return await Database.UpdateAsync(item);
			else
				return await Database.InsertAsync(item);
		}

		public async Task<int> SaveRecordAsync(CourseRecord courseRecord)
		{
			await Init();
			if (courseRecord.courseId != 0)
				return await Database.UpdateAsync(courseRecord);
			else
				return await Database.InsertAsync(courseRecord);
		}

		public async Task<int> SaveAssessmentAsync(AssessmentRecord assessmentRecord)
		{
			await Init();
			if (assessmentRecord.assessmentId != 0)
				return await Database.UpdateAsync(assessmentRecord);
			else
				return await Database.InsertAsync(assessmentRecord);
		}

		// public async Task<int> SaveInstructorAsync(InstructorRecord instructorRecord)
		// {
		//     await Init();
		//     if (instructorRecord.instructorId != 0)
		//         return await Database.UpdateAsync(instructorRecord);
		//     else
		//         return await Database.InsertAsync(instructorRecord);
		// }

		//Deleting the items

		public async Task<int> DeleteItemAsync(TermRecord item)
		{
			await Init();
			return await Database.DeleteAsync(item);
		}

		public async Task<int> DeleteRecordAsync(CourseRecord courseRecord)
		{
			await Init();
			return await Database.DeleteAsync(courseRecord);
		}

		public async Task<int> DeleteAssessmentAsync(AssessmentRecord assessmentRecord)
		{
			await Init();
			return await Database.DeleteAsync(assessmentRecord);
		}



		// public async Task<int> DeleteInstructorAsync(InstructorRecord instructorRecord)
		// {
		//    await Init();
		//     return await Database.DeleteAsync(instructorRecord);
		// }


		public async Task<string> GetTermNameValue(int termId)
		{
			// Assuming your GetItemAsync method takes the correct parameter
			TermRecord termDetails = await GetItemAsync(termId);

			if (termDetails != null)
			{
				return termDetails.termName;
			}

			return "DefaultTermName";
		}


	}
}






