using Notification.Wpf;

namespace PlantX.Notifications {
	public static class NotificationsManager {
		private static NotificationManager Notification = new NotificationManager();

		private static int notificationTimeInSeconds = 2;

		public static void ShowInfo(string content) {
			Notification.Show("Informacja", content, NotificationType.Information, expirationTime: TimeSpan.FromSeconds(notificationTimeInSeconds));
		}
		public static void ShowError(string content) {
			Notification.Show("Błąd", content, NotificationType.Error, expirationTime: TimeSpan.FromSeconds(notificationTimeInSeconds));
		}
		public static void ShowSuccess(string content) {
			Notification.Show("Sukces", content, NotificationType.Success, expirationTime: TimeSpan.FromSeconds(notificationTimeInSeconds));
		}
	}
}
