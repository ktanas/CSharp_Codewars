
public interface IWarrior
{
    // a.IsBetter(b) returns true if and only if
    // warrior a is no worse than warrior b, i.e. a>=b
    bool IsBetter(IWarrior other);
}

public static class Warriors
{
    // warriors is IWarrior[5]
    public static IWarrior SelectMedian(IWarrior[] warriors)
    {
        bool x1 = warriors[0].IsBetter(warriors[1]), x2 = warriors[2].IsBetter(warriors[3]);
        int w1, w2;
        if (x1 == true) w1 = 0; else w1 = 1;
        if (x2 == true) w2 = 2; else w2 = 3;
        bool x3 = warriors[w1].IsBetter(warriors[w2]);

        int a, b, c, d;

        if (x3 == true) a = w1; else a = w2;

        switch (a)
        {
            case 0:
                b = 1;
                break;
            case 1:
                b = 0;
                break;
            case 2:
                b = 3;
                break;
            case 3:
                b = 2;
                break;
            default:
                b = -1;
                break;
        };

        if (a < 2)
        {
            if (x2 == true) { c = 2; d = 3; } else { c = 3; d = 2; }
        }
        else
        {
            if (x1 == true) { c = 0; d = 1; } else { c = 1; d = 0; }
        }

        bool x4, x5, x6;

        x4 = warriors[b].IsBetter(warriors[4]);

        if (x4 == true)
        {
            x5 = warriors[b].IsBetter(warriors[c]);
            if (x5 == true)
            {
                x6 = warriors[c].IsBetter(warriors[4]);
                if (x6 == true) return warriors[c];
                else return warriors[4];
            }
            else // x5 == false
            {
                x6 = warriors[b].IsBetter(warriors[d]);
                if (x6 == true) return warriors[b];
                else return warriors[d];
            }
        }
        else // x4 == false
        {
            x5 = warriors[c].IsBetter(warriors[4]);
            if (x5 == true)
            {
                x6 = warriors[d].IsBetter(warriors[4]);
                if (x6 == true) return warriors[d];
                else return warriors[4];
            }
            else // x5 == false
            {
                x6 = warriors[b].IsBetter(warriors[c]);
                if (x6 == true) return warriors[b];
                else return warriors[c];
            }
        }
    }



}