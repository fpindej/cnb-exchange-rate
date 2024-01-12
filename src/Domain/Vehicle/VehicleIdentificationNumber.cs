namespace Domain.Vehicle;

public readonly struct VehicleIdentificationNumber
{
    private readonly string _vin;

    public VehicleIdentificationNumber(string vin)
    {
        _vin = vin;
    }

    public override string ToString()
    {
        return _vin;
    }

    public override bool Equals(object? obj)
    {
        if (obj is VehicleIdentificationNumber other) return _vin == other._vin;

        return false;
    }

    public override int GetHashCode()
    {
        return _vin.GetHashCode();
    }

    public static bool operator ==(VehicleIdentificationNumber left, VehicleIdentificationNumber right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(VehicleIdentificationNumber left, VehicleIdentificationNumber right)
    {
        return !(left == right);
    }
}