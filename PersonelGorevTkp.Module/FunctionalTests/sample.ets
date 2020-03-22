;#DropDB PersonelGorevTkpEasyTest

#Application PersonelGorevTkp.Win
#Application PersonelGorevTkp.Web

*FillForm
 User Name = Admin
*Action Log In

#IfDef PersonelGorevTkp.Win

*Action About...
 
*Action OK

#EndIf

#IfDef PersonelGorevTkp.Web
*Action Navigation(My Details)
#EndIf
