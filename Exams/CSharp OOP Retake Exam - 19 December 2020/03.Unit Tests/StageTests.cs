// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		private Song song;
		private Stage stage;
		private Performer performer;
		[Test]
	    public void ConstructorShouldCreateNewEmptyStage()
	    {
			stage = new Stage();
			Assert.AreEqual(0, stage.Performers.Count);
		}
		[Test]
        public void AddPerformerShouldSuccessfullyAddPerformerToStage()
        {
			stage = new Stage();
			performer = new Performer("Bate", "Pesho", 24);
			stage.AddPerformer(performer);
			Assert.AreEqual(1, stage.Performers.Count);
			Assert.True(stage.Performers.Any(s => s.FullName == "Bate Pesho" && s.Age == 24));
        }
		[Test]
        public void AddPerformerShouldThrowExceptionWhenPerformerAgeIsUnder18()
        {
			stage = new Stage();
			performer = new Performer("Bate", "Pesho", 14);
			Assert.Throws<ArgumentException>(() => { stage.AddPerformer(performer); }, "You can only add performers that are at least 18.");
		}
		//[Test]
  //      public void AddSongShouldThrowExceptionWhenSongNameIsNull()
  //      {
		//	stage = new Stage();
		//	song = new Song(null, new TimeSpan(1, 12, 23, 62));
		//	Assert.Throws<ArgumentNullException>(() => { stage.AddSong(song); }, null, "Can not be null!");
		//}
		[Test]
        public void AddSongShouldThrowExceptionWhenSongDurationIsLessThanOneMenute()
        {
			stage = new Stage();
			song = new Song(null, new TimeSpan(0, 0, 0, 0));
			Assert.Throws<ArgumentException>(() => { stage.AddSong(song); }, "You can only add songs that are longer than 1 minute.");
		}
		[Test]
        public void AddSongToPerformerShouldSuccessfullyAddSongToPerformer()
        {
			stage = new Stage();
			performer = new Performer("Bate", "Pesho", 24);
			song = new Song("Machkame", new TimeSpan(1, 12, 23, 62));
			stage.AddPerformer(performer);
			stage.AddSong(song);
			string actualResult = stage.AddSongToPerformer("Machkame", "Bate Pesho");
			string expectedResult = $"Machkame (24:02) will be performed by {performer.FullName}";
			Assert.AreEqual(expectedResult, actualResult);
		}
		[Test]
        public void PlayShouldPlayAllPerformersSongs()
        {
			stage = new Stage();
			performer = new Performer("Bate", "Pesho", 24);
			song = new Song("Machkame", new TimeSpan(1, 12, 23, 62));
			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSongToPerformer("Machkame", "Bate Pesho");
			string actualResult = stage.Play();
			string expectedResult = $"{stage.Performers.Count} performers played {stage.Performers.Sum(s=>s.SongList.Count)} songs";
			Assert.AreEqual(expectedResult, actualResult);
		}
		[Test]
		public void AddSongToPerformerShouldThrowExceptionWhenPerformerDoNotExist()
		{
			stage = new Stage();
			performer = new Performer("Bate", "Pesho", 24);
			song = new Song("Machkame", new TimeSpan(1, 12, 23, 62));
			stage.AddPerformer(performer);
			stage.AddSong(song);
			Assert.Throws<ArgumentException>(() => { stage.AddSongToPerformer("Machkame", "Nema nikoi"); });	
		}
		[Test]
		public void AddSongToPerformerShouldThrowExceptionWhenSongDoNotExist()
		{
			stage = new Stage();
			performer = new Performer("Bate", "Pesho", 24);
			song = new Song("Machkame", new TimeSpan(1, 12, 23, 62));
			stage.AddPerformer(performer);
			stage.AddSong(song);
			Assert.Throws<ArgumentException>(() => { stage.AddSongToPerformer("Never", "Bate Pesho"); });
		}
		[Test]
		public void AddSongToPerformerShouldThrowExceptionWhenSongNameIsNull()
		{
			stage = new Stage();
			performer = new Performer("Bate", "Pesho", 24);
			song = new Song("Machkame", new TimeSpan(1, 12, 23, 62));
			stage.AddPerformer(performer);
			stage.AddSong(song);
			Assert.Throws<ArgumentNullException>(() => { stage.AddSongToPerformer(null, "Bate Pesho"); }, "Can not be null!");

		}
	}
}