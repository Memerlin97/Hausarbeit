   M S B A M L   `   `   `  ����H  DZeiterfassung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ZeiterfassungZeiterfassung  5   	       Zeiterfassung.DataView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Zeiterfassung     5   	   -   5          � Title$  Daten Anzeige��5   	   $	��450��6   $	��650��6,    � WindowStartupLocation$ CenterScreen=�5	       .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $	��.1* �6   �� 5      �� 5      $	��.1* �6   .+�5   
   �� $��Restliche Urlaubstage:��6   �� 5   
   -   5         ��Name$ 
Resturlaub��5   ;   $��1��6   $
��Left=�6    6;   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��1��6%   $��2��62   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6F      AutoGenerateColumns .  ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Datum��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   �� *Datum+ �� StringFormat$ 
dd.MM.yyyy��  5      $	 von Uhrzeit��6%   
 6:   �� *
BeginnAZ+  5      $	 bis Uhrzeit��6%   
 6:   �� *EndeAZ+  5      $	 Davon Pause��6%   
 6:   �� *Pause+  5      $	 
ist Urlaub��6%   
 69   �� *Urlaub+  5       $	 ist Abwesenheit��6%   
 6>   �� *
sonstAbw+  5!      $	 netto Arbeitszeit��6%   
 6@   �� *	NettoAZ+5#      �� 5%   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $y�Hidden=�6;   .+�5&      �� $��Mitarbeiter��6   �� 5'      -   5         ��Name$ MA_id��5'       �� 	MaxLength$ 1��6%   $��50��63   $��2q�6>   5(      �� 5*   
   -   5         ��Name$ cancel��5*      $��
Schließen��6!   $��2��65   $��1��6B   $	��2.5q�6R   $��Right=�6_   6{   6�   5+      