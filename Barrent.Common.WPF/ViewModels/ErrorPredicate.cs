namespace Barrent.Common.WPF.ViewModels;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="value"></param>
/// <returns></returns>
public delegate bool ErrorPredicate<in T>(T value);
