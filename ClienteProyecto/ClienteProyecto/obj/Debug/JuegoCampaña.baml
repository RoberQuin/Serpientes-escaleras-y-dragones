   M S B A M L   `   `   `  ����<  8+, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ClienteProyectoClienteProyecto  5   	   G(clr-namespace:ClienteProyecto.PropertiesClienteProyecto.Properties  5   	   #    ClienteProyecto.JuegoCampaña   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ClienteProyecto     5   	   6p(clr-namespace:ClienteProyecto.Properties     5   	   *   $ClienteProyecto.Properties.Resources    windowCampaña � Title# Z  5	   	    � WindowState$ 	Maximized=�66   $
��1366��6N   $	��768��6[   .��5
      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFE6EAF7��6    � Offset$ 0.013Q�61   � 5      $ 	#FF93ABEE��6   $ 1Q�61   � 5      $ 	#FFAABCF1��6   $ 0.935Q�61   5      .+�5   
   �� ���	#FFF4F4F5$
��Left=�6%   $	��717��6@   $��
631,10,0,0q�6M   
���   �$	��Top=�6p   $	��717��6�   �� 5   
   -   5         ��Name$ 
tableroIMG��5      $
��Left=�6$   $	��717��6?   $��
631,10,0,0q�6L   $	��Top=�6`   $	��717��6x   $��imagenes/Tablero1MT.png��6�   �� 5   
   -   5        $ tuIMG��5      $
��Left=�6   $	��125��6:   $��
75,112,0,0q�6G   $	��Top=�6[   $	��120��6s   �� 5   
   -   5        $ oponenteIMG��5      $
��Left=�6%   $	��125��6@   $��350,112,0,0q�6M   $	��Top=�6b   $	��120��6z   �� 5   
   $�� ��6   $��Center=�6   $��408,536,806,0q�68   $	��Top=�6O   $��25(�6g   $��44��6u   $	��144��6�   �� 5   
   -   5        $ dadoIMG��5      $
��Left=�6!   $	��100��6<   $��222,512,0,0q�6I   $	��Top=�6^   $	��100��6v   $��Imagenes/dado1.png��6�   �� 5   
   -   5         ��Name$ tirarBT��5      	   buttonTirar#��Z	 6"   $
��Left=�6O   $��204,384,0,0q�6j   $	��Top=�6   $	��141��6�   $��42��6�   $��25(�6�   �� 5   
   -   5        $
��Left=�5      $��
10,658,0,0q�6,   $	��Top=�6@   $��79��6X   $��69��6c   .��5      �� .+�5      �� $��imagenes/abandonar.png��6   $��28��68   $��24��6D   
 J� RenderTransformOrigin$
 0.5,0.5&�6O   z�5      V� 5      .~�5      �� �� 5       �� 5!       �� Angle$ -181.541Q�6.   T� 5"      5#      5%      5&      5'      � 5(   
   -   5         �Name$ 	tableroGD��5(      $
��Left=�6"   $	��717��6=   $��
631,10,0,0q�6J   $	��Top=�6^   $	��717��6v    � ColumnDefinitions 5)      �� 5*      -   5         ��Name$ C1��5*   /   $	��74* �6#   6/   �� 5+      -	   5        $ C2��5+   /   $	��67* �6#   6/   �� 5,      -
   5        $ C3��5,   /   $	��76* �6#   6/   �� 5-      -   5        $ C4��5-   /   $	��69* �6#   6/   �� 5.      -   5        $ C5��5.   /   $	��72* �6#   6/   �� 5/      -   5        $ C6��5/   /   $	��71* �6#   6/   �� 50      -   5        $ C7��50   /   $	��71* �6#   6/   �� 51      -   5        $ C8��51   /   $	��74* �6#   6/   �� 52      -   5        $ C9��52   /   $	��72* �6#   6/   �� 53      -   5        $	 C10��53   /   $	��71* �6#   6/    � RowDefinitions 55      �� 56      -   5         ��Name$ R1��56   -   $	��73* �6    6-   �� 57      -   5        $ R2��57   -   $	��69* �6    6-   �� 58      -   5        $ R3��58   -   $	��76* �6    6-   �� 59      -   5        $ R4��59   -   $	��72* �6    6-   �� 5:      -   5        $ R5��5:   -   $	��68* �6    6-   �� 5;      -   5        $ R6��5;   -   $	��72* �6    6-   �� 5<      -   5        $ R7��5<   -   $	��74* �6    6-   �� 5=      -   5        $ R8��5=   -   $	��69* �6    6-   �� 5>      -   5        $ R9��5>   -   $	��74* �6    6-   �� 5?      -   5        $	 R10��5?   -   $	��70* �6    6-   .+�5A      �� -   5        $ fichaJugadorIMG��5A      $��Center=�6-   $��62��6J   $��62��6V   $��imagenes/enemigo5.png��6a   $��9��6�   $��0��6�   $y�Visible=�6�   �� 5B      -   5        $ fichaEnemigoIMG��5B      $��Center=�6-   $��62��6J   $��62��6V   $��imagenes/enemigo1.png��6a   $��9��6�   $��0��6�   $y�Visible=�6�   5C      �� 5D   
   -   5         ��Name$
 tuLB��5D         labelTu#��Z 6   $
��Left=�6G   $��108,278,0,0q�6b   $	��Top=�6w   $��25(�6�   �� 5E   
   -   5        $ 
oponenteLB��5E         labelOponente#��Z 6$   $
��Left=�6S   $��366,278,0,0q�6n   $	��Top=�6�   $��25(�6�   5F      5G      