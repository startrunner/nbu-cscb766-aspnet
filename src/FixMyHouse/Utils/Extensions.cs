namespace FixMyHouse.Utils;

internal static class Extensions
{
    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> map, TKey key, Func<TValue> factory)
    {
        if (!map.TryGetValue(key, out TValue? value))
        {
            map[key] = value = factory();
        }

        return value;
    }

    public static IReadOnlyList<T> IReadOnly<T>(this IReadOnlyList<T> x) => x;

    public static TValue? GetValueOrNull<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> map, TKey key) where TValue : struct
    {
        if (map.TryGetValue(key, out TValue value)) { return value; }
        return null;
    }

    public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
    {
        foreach (var item in items)
        {
            action.Invoke(item);
        }
    }
}
