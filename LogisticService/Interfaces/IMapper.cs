namespace LogisticService.Interfaces
{
    internal interface IMapper<TEntity, TDto>
    {
        TDto ToDto(TEntity entity);

        TEntity FromDto(TDto dto);
    }
}
