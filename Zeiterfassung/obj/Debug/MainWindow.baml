   M S B A M L   `   `   `  ����H  DZeiterfassung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ZeiterfassungZeiterfassung  5   	       Zeiterfassung.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Zeiterfassung     5   	   -   5          � Title$  
MainWindow��5   	   $	��250��6   $	��500��6)    � WindowStartupLocation$ CenterScreen=�5	       .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��.05* �6   �� 5      �� 5      �� 5      $
��.05* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      �� 5      $	��.1* �6   .+�5   
   o� $��1��6   .@�5      m� -   5        $��Präferenzen��5      6,   5   
   �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6%   .+�5      �� $��Mitarbeiterkennung��6   �� 5      -   5         ��Name$ MA_id��5       �� 	MaxLength$ 3��6%   $	��100��63   $��2q�6?   5      �� 5    
   -   5         ��Name$
 view��5       $��1��6   $��1��6,   $��Daten einsehen��6<   $��3q�6U   6`   �� 5!   
   -   5        $ 
enter_work��5!      $��2��6%   $��1��62   $��2��6B   $��Arbeitszeit eintragen��6V   $��3q�6v   6�   �� 5"   
   -   5        $ 
enter_away��5"      $��1��6%   $��2��62   $��Abwesenheit eintragen��6B   $��3q�6b   6m   5$      5%      