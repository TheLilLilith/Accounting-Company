   M S B A M L   `   `   `  ����X  TAccountingConstructionCompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:AccountingConstructionCompanyAccountingConstructionCompany  5      0    *AccountingConstructionCompany.RegisterPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      9local+clr-namespace:AccountingConstructionCompany   5        N� Title$  RegisterPage��5
      .��5      � .+�5   
   ��  �� CornerRadius$ 20,20,20,20��6   $��0,10,0,0q�6,   $	��450��6>   $	��300��6J   
�������._�5      �� .+�5      �� $��Регистрация��6   
���   �$��Open Sans Bold)�6B   $��25(�6^   $��Center=�6l   $��0,10,0,0q�6�   $
��Bold"�6�   6�   � 5      $��	60,10,0,0q�6   .+�5      �� -   5         ��Name$ 
LogTextBox��5      $��0,0,0,0q�62   $	��160��6C   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��6O      MaterialDesignFilledTextBox#��[  5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �   �   
Foreground
 �   ���5      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�5      G� 5      -   5        $��PassTextBox��5   @   $��10,0,0,0q�6"   $	��160��64    ) %MaterialDesignFilledRevealPasswordBox#��[ 5   "   $ Пароль��5   "      HasClearButton . 
 �   �
 �   �{�5   "   �� *	IsChecked+ �� ElementName$# RevealPasswordOutlinedEnabled��5   "   5      � 5       $��60,5,0,0q�6   .+�5"      �� -   5        $ NameTextBox��5"      $��0,0,0,0q�63   $	��160��6D   $ Имя��6P   #��[  5#      
 �   �
 �   ���5$      �� *Name+$ PropertyChanged=�5&      �� 5(      -   5        $ 
SurTextBox��5(      $��10,0,0,0q�62   $	��160��6D   $ Фамилия��6P   #��[  5)      
 �   �
 �   ���5*      �� *Name+$ PropertyChanged=�5,      5-      � 5.      $��60,5,0,0q�6   .+�50      �� -   5        $ PatronymicTextBox��50      $��0,0,0,0q�69   $	��160��6J   $ Отчество��6V   #��[  51      
 �   �
 �   ���52      �� *Name+$ PropertyChanged=�54      �� 55      -   5        $��HideCheckBox��55      $��Отсутствует��6N   $��10,0,0,0q�6d   6x   56      � 57      $��60,5,0,0q�6   .+�59      �� -   5        $ PhoneTextBox��59      $��0,0,0,0q�64   $	��160��6E   $! Номер телефона��6Q   #��[  5:      
 �   �
 �   ���5;      �� *Name+$ PropertyChanged=�5=      �� 5?      -   5        $ MailTextBox��5?      $��10,0,0,0q�63   $	��160��6E   $' !Электронный адрес��6Q   #��[  5@      
 �   �
 �   ���5A      �� *Name+$ PropertyChanged=�5C      5D      � 5E      $��	70,10,0,0q�6   .+�5G      �� -	   5        $��
BackButton��5G   \   $��
Назад��6   ���#fcd464
������ $��0,0,0,0q�6�   $	��150��6�   $��0q�6�   �� 5I      -
   5        $��AcceptRegButton��5I   Q     MaterialDesignRaisedButton#��[ 6   $��Принять��6�   ���#fcd464
���   �$��10,0,0,0q�6�   $	��150��6�   5J      5K      5L      5M      5N      