   M S B A M L   `   `   `  ����A  =yoxla2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:yoxla2yoxla2  5   	   e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089wTclr-namespace:System.Windows.Controls.Ribbon;assembly=System.Windows.Controls.RibbonSystem.Windows.Controls.Ribbon 5   	       yoxla2.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:yoxla2     5   	   gribbonTclr-namespace:System.Windows.Controls.Ribbon;assembly=System.Windows.Controls.Ribbon     5   	   -   5          �Name$  
WPF_WINDOW��5   	    � Title$ 
MainWindow��5
   	   $	��622��6   $
��1389��6)   .��5      � .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  $��1��6   $��	5,0,1,344q�6,      ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      5  /System.Windows.Controls.Ribbon.RibbonMenuButton   SmallImageSource$ img/files.jpg��6(   .@�5      >  8System.Windows.Controls.Ribbon.RibbonApplicationMenuItem  -   5        $��save_as��5   0   $��Save As��6?   3  -System.Windows.Controls.Ribbon.RibbonMenuItem   ImageSource$ img/save-as.jpg��6P   6n     5      -   5        $
��open��5   0   $
��Open��6<   $ img/open.png��6J   6e     5      -   5        $
��exit��5   0   $
��Exit��6<   $ img/exit.png��6J   6e   5      .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  -   5        $
��tab1��5      $
��Home��6$   $��
0,0,-2,-12q�62   .@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5        $��group1��5      $��Image operations��6,   .@�5      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5        $��	monocrome��5   #      Label$ Monochromic��64      LargeImageSource$ img/monochrome.png��6H   6n     5      -   5        $��mirror��5   #   $ Mirror��61   $ img/mirror.png��6@   $��66��6b   $��85��6n   6y   5        5      -	   5        $
��tab2��5      $��Simple operations��6*   $	��0,1q�6E   $	��110��6R   .@�5        -
   5        $
��zoom��5   #   $
 zoom��6/   $ img/zoom.png��6<   $��-5,0,-83,-20q�6\   $��65��6r   $	��Top=�6    J� RenderTransformOrigin$ -0.011,0.569&�6�   5      5      5      �� 5    
   -   5        $��origin��5    �   $��Uniform=�6    �� Left$ 60��6$   $
��Left=�66   $	��300��6Q   $	��Top=�6^   $	��345��6v   $��img/plus.png��6�   
	 �� Top$		 166��6�   $��	0,160,0,0q�6�   6�   �� 5!   
   -   5        $��status��5!   E   
 �� Right$
 10��6    �� Bottom$ 10��6"   $��Label��65   $
��Left=�6T   $	��Top=�6o   $	 852��6�   $		 489��6�   $ 0.263,1.769&�6�   $��1315,555,0,0q�6�   $��45��6�   �� 5%   
   -   5        $��border��5%   %   }�. $��610,150,6,55q�63   ._�5&      �� -   5        $��custom��5&   s   $��Uniform=�6   $��Right=�6&   $	��300��6B   $	��Top=�6O   $	��375��6g   $��img/gray.png��6�   $��3��6�   $��2��6�   $��
0,20,170,0q�6�   6M  5'      5(      5)      