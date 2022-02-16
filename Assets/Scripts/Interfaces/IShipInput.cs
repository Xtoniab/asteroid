public interface IShipInput
{
    void ReadInput(); // Чтение ввода
    float Rotation { get; } // Поворот
    float Thrust { get; } // Ускорение
}
