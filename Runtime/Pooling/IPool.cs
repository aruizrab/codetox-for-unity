using System;
using JetBrains.Annotations;

namespace Codetox.Pooling
{
    /// <summary>
    ///     Defines methods to manipulate a pool.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the pool.</typeparam>
    public interface IPool<T>
    {
        /// <summary>
        ///     Gets the total number of objects the <see cref="IPool{T}" /> can contain.
        /// </summary>
        /// <value>The total number of objects the <see cref="IPool{T}" /> can contain.</value>
        int Capacity { get; }

        /// <summary>
        ///     Gets the number of elements contained in the <see cref="IPool{T}" />.
        /// </summary>
        /// <value>The number of elements contained in the <see cref="IPool{T}" />.</value>
        int Count { get; }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="IPool{T}" /> is empty.
        /// </summary>
        /// <value><c>true</c> if the <see cref="IPool{T}" /> is empty; otherwise, <c>false</c>.</value>
        /// <remarks>A pool is empty when <see cref="Count" /> is equal to 0.</remarks>
        bool IsEmpty { get; }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="IPool{T}" /> is full.
        /// </summary>
        /// <value><c>true</c> if the <see cref="IPool{T}" /> is full; otherwise, <c>false</c>.</value>
        /// <remarks>A pool is full when <see cref="Count" /> is equal to <see cref="Capacity" />.</remarks>
        bool IsFull { get; }

        /// <summary>
        ///     Gets an object from the <see cref="IPool{T}" />.
        /// </summary>
        /// <returns>An object from the <see cref="IPool{T}" />.</returns>
        /// <remarks>
        ///     <para>
        ///         Once an object is retrieved from the pool, that object can't be retrieved again until returned to the pool
        ///         via <see cref="Return" /> method.
        ///     </para>
        ///     <para>If the pool <see cref="IsEmpty" />, a new object will be instantiated and returned.</para>
        /// </remarks>
        [NotNull]
        T Get();

        /// <summary>
        ///     Returns an object back to the <see cref="IPool{T}" />.
        /// </summary>
        /// <param name="obj">The object to be returned to the <see cref="IPool{T}" />.</param>
        /// <exception cref="ArgumentNullException"><c>obj</c> is <c>null</c>.</exception>
        /// <remarks>
        ///     <para>Once an object is returned to the pool, it can be retrieved again via <see cref="Get" /> method.</para>
        ///     <para>If the pool <see cref="IsFull" />, the object is ignored.</para>
        /// </remarks>
        void Return([NotNull] T obj);

        /// <summary>
        ///     Removes all objects from the <see cref="IPool{T}" />.
        /// </summary>
        /// <remarks><see cref="Count" /> is set to 0. <see cref="Capacity" /> remains unchanged.</remarks>
        void Clear();

        /// <summary>
        ///     Determines whether an object is in the <see cref="IPool{T}" />.
        /// </summary>
        /// <param name="obj">The object to locate in the <see cref="IPool{T}" />.</param>
        /// <returns><c>true</c> if <c>obj</c> is found in the <see cref="IPool{T}" />; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><c>obj</c> is <c>null</c>.</exception>
        /// <remarks>
        ///     <para>This method determines equality using <c>Equals(obj)</c>.</para>
        ///     <para>
        ///         This method performs a linear search; therefore, this method is an O(n) operation, where n is
        ///         <see cref="Count" />.
        ///     </para>
        /// </remarks>
        bool Contains([NotNull] T obj);

        /// <summary>
        ///     Performs the specified action on each object in the <see cref="IPool{T}" />.
        /// </summary>
        /// <param name="action">The <see cref="Action{T}" /> delegate to perform on each element of the <see cref="IPool{T}" />.</param>
        /// <exception cref="ArgumentNullException"><c>action</c> is <c>null</c>.</exception>
        /// <remarks>This method is an O(n) operation, where n is <see cref="Count" />.</remarks>
        void ForEach([NotNull] Action<T> action);
    }
}