   M S B A M L   `   `   `  ����D  @FluentWPF, Version=0.9.0.1, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF  5      E ANetCoreWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NetCoreWpf
NetCoreWpf 5         NetCoreWpf.SQLCmdWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Efw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF     5      *localclr-namespace:NetCoreWpf     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962af	 bMaterialDesignThemes.MahApps, Version=0.1.7.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  	 5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006  	 5	      T
 PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f@metroControls,http://metro.mahapps.com/winfx/xaml/controls 
 5
      _ [ICSharpCode.AvalonEdit, Version=6.0.1.278, Culture=neutral, PublicKeyToken=9cc39be672370310;syntax.http://icsharpcode.net/sharpdevelop/avalonedit  5        � Title$  Query Builder Window��5      $	��474��5      $	��364��5         Theme_1#���   5      $	��1.5q�5        
Accent700S( 
 "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �  5         ShowCloseButton$ False��5         ShowMaxRestoreButton$ False��5         ShowMinButton$ False��5         ShowTitleBar$ False��5       � WindowStartupLocation$ CenterScreen=�5      .��5      � -   5         �Name$ RootGrid��5      .+�5   
   '  !ICSharpCode.AvalonEdit.TextEditor  -   5          Name$ queryTextBox��5      $��	0,64,0,62q�5        Theme_2#���  5        
Accent400S#���  5      $��0,0.5,0,0.5q�5        ThemeForeground#���  5      $	   HorizontalScrollBarVisibility$	 Hidden=�5       
   LineNumbersForeground#
 �  5!         ShowLineNumbers$
 True��5"         SyntaxHighlightingM  GICSharpCode.AvalonEdit.Highlighting.HighlightingDefinitionTypeConverter$	 SQL 5#      "   VerticalScrollBarVisibility$
 Auto=�5$      �� 5%   
   -   5         ��Name$ ExitBtn��5&      $��32��5'      $��32��5(      $��	0,10,24,0q�5)      $��Right=�5*      $	��Top=�5+        ExitBtnStyle#���  5-      d� 5.   
   -   5         d�Name$ 	MaxResBtn��5/      $��32��50      $��32��51      $��	0,10,56,0q�52      $��Right=�53      $	��Top=�54        MaxResBtnStyle#���  56      �� 57   
   -   5        $ TrayBtn��58      $��32��59      $��32��5:      $��	0,10,88,0q�5;      $��Right=�5<      $	��Top=�5=        TrayBtnStyle#���  5?      �� 5@   
   -   5        $ executeQuery��5A      $	��105��5B      $��27��5C      $��	0,0,15,20q�5D      $��Right=�5E      $��Bottom=�5F       
 Accept#���  5H       	 DefaultBtnStyle#��� 	 5I       J� Effect 5J      3  -System.Windows.Media.Effects.DropShadowEffect  5K         
BlurRadius$ 7Q�5L         	Direction$	 -85Q�5M         RenderingBias$ Quality=�5N         ShadowDepth$ 1Q�5O      5Q      �� 5R   
   $	��245��5S      $��39��5T      $��	30,10,0,0q�5U      $
��Left=�5V      $	��Top=�5W      $��Center=�5X       
 QueryBuilder#��� 
 5Y      $��Roboto)�5Z      $��22(�5[      #���  5\      5]      5^      