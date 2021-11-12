namespace DesignPatterns.AdapterPattern
{
    /// <summary>
    /// ����� ����
    /// �ڵ带 �����ϱ� ���� ������ �����ϴ� ����
    /// </summary>
    public class Kitchen
    {
        public static IFoodMixer GetInstance()
        {
            return new FoodProcesser();
        }
    }

    public interface IFoodMixer //Target
    {
        float Value { get; }
        void Mix(float value);
    }

    public class FoodProcesser : IFoodMixer //Adapter
    {
        private Mortar _mortar;

        public FoodProcesser()
        {
            _mortar = new Mortar();
        }

        public float Value => (int)_mortar.Value;

        public void Mix(float value)
        {
            _mortar.Mix((int)value);
        }
    }

    public class Mortar //Adaptee
    {
        private int _value;

        public int Value => _value;

        public void Mix(int value)
        {
            _value += value;
        }
    }
}
