   M S B A M L   `   `   `  ����H  DZeiterfassung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ZeiterfassungZeiterfassung  5   	       Zeiterfassung.WorkTime   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Zeiterfassung     5   	   -   5          � Title$  Arbeitszeit eintragen��5   	   $	��175��6'   $	��300��64    � WindowStartupLocation$ CenterScreen=�5	       .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6   $��Datum��6-   (  "System.Windows.Controls.DatePicker  5   
   -   5        $
��Date��5      $��1��6!   $��0��6.   $��3,0,3,0q�6>   $��2��6O      Text 6c   �� *Datum+ �� Mode$ OneWayToSource=��� 5   
   $��2��6   $��0��6   $��von Uhrzeit��6-   �� 5   
   $��2��6   $��1��6   $��bis Uhrzeit��6-   �� 5   
   -   5         ��Name$ Start��5      $��3��6!   $��0��6.   $��3,0,3,0q�6>    �� 	MaxLength$ 4��6O   ��5      �� *
BeginnAz+$ OneWayToSource=��� 5    
   -   5        $	 End��5       $��3��6   $��1��6,   $��3,0,3,0q�6<   $ 4��6M   ��5!      �� *EndeAZ+$ OneWayToSource=��� 5#   
   $��4��6   $��0,3,5,3q�6"    �� Orientation$ 
Horizontal=�63   $��Right=�6L   $��2��6h   .+�5$      �� -   5        	 ��Name$	 cancel��5$      $��	Abbrechen��6%   $��0,0,5,0q�69   6J   �� 5%      -   5        $
	 save��5%      $��	Speichern��6#   67   5&      �� 5'   
   $��4��6   $ 
Horizontal=�6"   $y�Hidden=�6;   .+�5(      �� $��Mitarbeiter��6   �� 5)      -   5        $ MA_id��5)      $ 1��6%   $��50��63   $��2q�6>   5*      5+      5,      