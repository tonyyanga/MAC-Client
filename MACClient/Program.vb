Imports DevExpress.UserSkins
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel

Namespace CsWinFormsBlackApp
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread>
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)

			BonusSkins.Register()
			SkinManager.EnableFormSkins()
			UserLookAndFeel.Default.SetSkinStyle("DevExpress Style")
            Application.Run(New main())
		End Sub
	End Class
End Namespace
