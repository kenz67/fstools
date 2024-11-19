using fstools.Services;
using Moq;

namespace fstoolsTests.Services
{
    [TestClass()]
    public class FsTimerTests
    {
        [TestMethod()]
        public void StartTimerTest()
        {
            var svc = new FsTimer();

            var mockCallback = new Mock<Func<TimeSpan, Task>>();
            var callbackInvoked = new ManualResetEventSlim(false);

            mockCallback
                .Setup(c => c(It.IsAny<TimeSpan>()))
                .Callback<TimeSpan>(_ => callbackInvoked.Set())
                .Returns(Task.CompletedTask);

            svc.StartTimer(mockCallback.Object);

            // Wait for the callback to be invoked
            var callbackCalled = callbackInvoked.Wait(500); // Wait up to 500ms

            // Assert
            Assert.IsTrue(callbackCalled, "Callback was not invoked.");
            mockCallback.Verify(c => c(It.Is<TimeSpan>(t => t > TimeSpan.Zero)), Times.AtLeastOnce(), "Callback was not invoked with valid elapsed time.");

            svc.StopTimer();
        }

        [TestMethod()]
        public void PauseResumeTimerTest()
        {
            var svc = new FsTimer();

            var mockCallback = new Mock<Func<TimeSpan, Task>>();
            var callbackInvoked = new ManualResetEventSlim(false);

            mockCallback
                .Setup(c => c(It.IsAny<TimeSpan>()))
                .Callback<TimeSpan>(_ => callbackInvoked.Set())
                .Returns(Task.CompletedTask);

            svc.StartTimer(mockCallback.Object);
            Thread.Sleep(200);
            svc.PauseTimer();
            var time1 = svc.FormattedTime();
            Thread.Sleep(200);
            var time2 = svc.FormattedTime();

            Assert.AreEqual(time1, time2);

            svc.ResumeTimer();
            Thread.Sleep(200);
            var time3 = svc.FormattedTime();

            Assert.AreNotEqual(time2, time3);

            svc.StopTimer();
        }

        [TestMethod()]
        public void StopTimerTest()
        {
            var svc = new FsTimer();

            var mockCallback = new Mock<Func<TimeSpan, Task>>();
            var callbackInvoked = new ManualResetEventSlim(false);

            mockCallback
                .Setup(c => c(It.IsAny<TimeSpan>()))
                .Callback<TimeSpan>(_ => callbackInvoked.Set())
                .Returns(Task.CompletedTask);

            svc.StartTimer(mockCallback.Object);

            svc.StopTimer();

            Assert.AreEqual("00:00:00.0", svc.FormattedTime());
        }

        [TestMethod()]
        public void StopTimerTest2()
        {
            var svc = new FsTimer();
            svc.StopTimer();
            Assert.AreEqual("00:00:00.0", svc.FormattedTime());
        }

        [TestMethod()]
        public void SetCallbackTest()
        {
            var svc = new FsTimer();

            var mockCallback = new Mock<Func<TimeSpan, Task>>();
            var callbackInvoked = new ManualResetEventSlim(false);

            mockCallback
                .Setup(c => c(It.IsAny<TimeSpan>()))
                .Callback<TimeSpan>(_ => callbackInvoked.Set())
                .Returns(Task.CompletedTask);

            svc.StartTimer(mockCallback.Object);
            svc.StartTimer(mockCallback.Object);

            // Wait for the callback to be invoked
            var callbackCalled = callbackInvoked.Wait(500); // Wait up to 500ms

            // Assert
            Assert.IsTrue(callbackCalled, "Callback was not invoked.");
            mockCallback.Verify(c => c(It.Is<TimeSpan>(t => t > TimeSpan.Zero)), Times.AtLeastOnce(), "Callback was not invoked with valid elapsed time.");

            svc.StopTimer();
        }
    }
}