   M S B A M L   `   `   `  ����D  @FluentWPF, Version=0.9.0.1, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF  5      E ANetCoreWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NetCoreWpf
NetCoreWpf 5         NetCoreWpf.TablesWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Efw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF     5      *localclr-namespace:NetCoreWpf     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962af	 bMaterialDesignThemes.MahApps, Version=0.1.7.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  	 5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006  	 5	      T
 PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f@metroControls,http://metro.mahapps.com/winfx/xaml/controls 
 5
        � Title$  Tables Window��5      $	��304��5      $	��414��5         Theme_1#���   5      $	��1.5q�5        
Accent700S( 
 "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �  5       � 
ResizeMode$ NoResize=�5         ShowCloseButton$ False��5         ShowMaxRestoreButton$ False��5         ShowMinButton$ False��5         ShowTitleBar$ False��5       � WindowStartupLocation$ CenterScreen=�5      .��5      � -   5         �Name$ RootGrid��5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        	  Name$	 tablesDataGrid��5      $��	0,45,0,81q�5      
   AutoGenerateColumns$

 True��5        Theme_2#���  5        
Accent400S#���  5      $��0,0.5,0,0.5q�5         CanUserAddRows$ False��5          CanUserDeleteRows$ False��5!         CanUserReorderColumns$ False��5"        CustomDataGridCell   	CellStyle# �  5#        CustomDataGridColumnHeader   ColumnHeaderStyle# �  5$         FrozenColumnCount$ 0��5%         GridLinesVisibility$
 None=�5&        Theme_3   HorizontalGridLinesBrush# �  5'         
IsReadOnly$
 True��5(        CustomDataGridRow   RowStyle# �  5)      �� 5*   
   -   5         ��Name$ SelectTableBtn��5+      $��25��5,      $��
36,0,36,36q�5-      $��Bottom=�5.       
 Accept#���  50       	 LoginBtnStyle#��� 	 51      �� 52   
   -   5        $ ExitBtn��53      $��32��54      $��32��55      $��	0,10,20,0q�56      $��Right=�57      $	��Top=�58       
 ExitBtnStyle#��� 
 5:      �� 5;   
   $	��180��5<      $��20,6,0,0q�5=      $
��Left=�5>      $	��Top=�5?       
 Tabels#���  5@      $��Roboto)�5A      $��20(�5B        ThemeForeground#���  5C      5D      5E      