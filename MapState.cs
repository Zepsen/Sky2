namespace Sky
{
    public struct MapState
    {
        private int AA, AB, AC, AD,
                    BA, BB, BC, BD,
                    CA, CB, CC, CD,
                    DA, DB, DC, DD;

        public MapState(MapState map)
        {
            AA = map.AA; AB = map.AB; AC = map.AC; AD = map.AD;
            BA = map.BA; BB = map.BB; BC = map.BC; BD = map.BD;
            CA = map.CA; CB = map.CB; CC = map.CC; CD = map.CD;
            DA = map.DA; DB = map.DB; DC = map.DC; DD = map.DD;
        }

        public void Set(int x, int y, int val)
        {
            switch (x)
            {
                case 0 when y == 0: AA = val; break;
                case 0 when y == 1: AB = val; break;
                case 0 when y == 2: AC = val; break;
                case 0 when y == 3: AD = val; break;
                
                case 1 when y == 0: BA = val; break;
                case 1 when y == 1: BB = val; break;
                case 1 when y == 2: BC = val; break;
                case 1 when y == 3: BD = val; break;

                case 2 when y == 0: CA = val; break;
                case 2 when y == 1: CB = val; break;
                case 2 when y == 2: CC = val; break;
                case 2 when y == 3: CD = val; break;

                case 3 when y == 0: DA = val; break;
                case 3 when y == 1: DB = val; break;
                case 3 when y == 2: DC = val; break;
                case 3 when y == 3: DD = val; break;
            }                
        }

    }
}
