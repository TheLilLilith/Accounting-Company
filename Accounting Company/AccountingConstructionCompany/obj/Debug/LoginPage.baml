   M S B A M L   `   `   `  ����X  TAccountingConstructionCompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:AccountingConstructionCompanyAccountingConstructionCompany  5      -    'AccountingConstructionCompany.LoginPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:AccountingConstructionCompany     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5        N� Title$  	LoginPage��5
      .��5      � .+�5   
   ��  �� CornerRadius$ 20,20,20,20��6   $��0,10,0,0q�6,   $	��450��6?   $	��300��6K   
�������._�5      �� $��1��6   $��1��6)   .+�5      �� $&�� Добро пожаловать!��6   
���   �$��Open Sans Bold)�6D   $��25(�6`   $��Center=�6n   $��0,10,0,0q�6�   $
��Bold"�6�   6�   �� 5      $5��/Войдите, чтобы продолжить��6   
���   �$��	Open Sans)�6L   $��15(�6c   $��Center=�6q   $��0,10,0,0q�6�   6�   �� 5      -   5         ��Name$ NameTextBox��5      $��
80,10,80,0q�6+   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$% Имя пользователя��6?    !  MaterialDesignOutlinedTextBox#��[  5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �   �   
Foreground
 �   �   
Background
 �����   FloatingScale$	 0.9Q�5      ��5      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�5      G� 5      -   5        $��PassTextBox��5   .   $��
80,10,80,0q�6    + 'MaterialDesignOutlinedRevealPasswordBox#��[ 5      $ Пароль��5      
 �   �
 �   �
 �����$	 0.9Q�5       	   HasClearButton	 . {�5      �� *	IsChecked+
 �� ElementName$#
 RevealPasswordOutlinedEnabled��5!      �� 5$      -   5        $��EnterButton��5$   I     MaterialDesignRaisedButton#��[ 6   $��
Войти��6w   ���#fcd464
���   �$��0,20,0,0q�6�   $	��200��6�   �� 5%      -   5        $��RegisterButton��5%   a   $*��$Зарегистрироваться��6   ���#fcd464
������ $��0,5,0,0q�6�   $	��200��6�   $��0q�6�   5(      5)      5*      5+      