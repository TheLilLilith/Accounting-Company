   M S B A M L   `   `   `  ����X  TAccountingConstructionCompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:AccountingConstructionCompanyAccountingConstructionCompany  5      1    +AccountingConstructionCompany.DashboardPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:AccountingConstructionCompany     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5        N� Title$  DashboardPage��5
      .��5      � 
������  � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $	��22* �6   .+�5   
   �� $��	Dashboard��6   $��0��6$   
���   �$��Open Sans Bold)�6E   $��25(�6a   $
��Left=�6o   $	��Top=�6�   $��	10,10,0,0q�6�   $
��Bold"�6�   6�   �� 5   
   $��1��6   $	��400��6     �� CornerRadius$ 	20,0,0,30��6-   $	��800��6F   
�������$��0,0,0,0q�6e   ._�5      �� $��20q�6   .+�5      � $��20,0,0,0q�6   .+�5      �� .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ UserPlus=�6.   $��Center=�6?   $��Center=�6\   $	��106��6w   $��89��6�   6�   �� 5      $#��Активные заявки��6   $��0��67   
���   �$��Open Sans Bold)�6X   $��20(�6t   $��Center=�6�   $
��Bold"�6�   6�   �� 5      -   5        $��ActiveOrdersTextBlock��5       $��0��6=   $��0��6F   
���   �$��Open Sans Bold)�6g   $��25(�6�   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   6�   5      �� 5      .+�5        $ 
UserCancel=�6.   $��Center=�6A   $��Center=�6^   $	��106��6y   $��89��6�   6�   �� 5      $'��!Отмененные заявки��6   $��0��69   
���   �$��Open Sans Bold)�6Z   $��20(�6v   $��Center=�6�   $
��Bold"�6�   6�   �� 5      -   5        $��CancelledOrdersTextBlock��5       $��0��6@   $��0��6I   
���   �$��Open Sans Bold)�6j   $��25(�6�   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   6�   5      �� 5       .+�5!        $ 	UserCheck=�62   $��Center=�6D   $��Center=�6a   $	��106��6|   $��89��6�   6�   �� 5"      $)��#Завершенные заявки��6    $��0��6>   
���   �$��Open Sans Bold)�6_   $��20(�6{   $��Center=�6�   $
��Bold"�6�   6�   �� 5#      -   5        $��ConfirmedOrdersTextBlock��5#   $   $��0��6D   $��0��6M   
���   �$��Open Sans Bold)�6n   $��25(�6�   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   6�   5$      5%      � 5&      $��90,0,0,0q�6   .+�5'      �� .+�5(        $��Center=�62   $��Center=�6O   $ Money=�6j   $	��106��6w   $��89��6�   6�   �� 5)      $��Center=�6    $��Center=�6=   $��Выручка��6X   $��0��6j   
���   �$��Open Sans Bold)�6�   $��20(�6�   $
��Bold"�6�   6�   �� 5*      -   5        $��IncomeTextBlock��5*   $   $��Center=�6;   $��Center=�6X   $��0��6s   $��0��6|   
���   �$��Open Sans Bold)�6�   $��25(�6�   $
��Bold"�6�   6�   5+      �� 5,      $��30,0,0,0q�6!   .+�5-        $ 	Warehouse=�62   $��Center=�6D   $��Center=�6a   $	��106��6|   $��89��6�   6�   �� 5.      $��Center=�6    $��Center=�6=   $&�� Товаров на складе��6X   $��0��6t   
���   �$��Open Sans Bold)�6�   $��20(�6�   $
��Bold"�6�   6�   �� 5/      -   5        $��ProductsTextBlock��5/   $   $��Center=�6=   $��Center=�6Z   $��0��6u   $��0��6~   
���   �$��Open Sans Bold)�6�   $��25(�6�   $
��Bold"�6�   6�   50      �� 51      $��10,0,0,0q�6"   .+�52        $ OrderCheckboxAscending=�62   $��Center=�6P   $��Center=�6m   $	��106��6�   $��89��6�   6�   �� 53      $��Center=�6    $��Center=�6=   $&�� Заказов в системе��6X   $��0��6t   
���   �$��Open Sans Bold)�6�   $��20(�6�   $
��Bold"�6�   6�   �� 54      -   5        $��OrdersTextBlock��54   $   $��Center=�6;   $��Center=�6X   $��0��6s   $��0��6|   
���   �$��Open Sans Bold)�6�   $��25(�6�   $
��Bold"�6�   6�   55      56      57      58      59      5:      