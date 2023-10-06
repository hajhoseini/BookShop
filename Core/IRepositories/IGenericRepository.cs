﻿namespace Core.IRepositories;

public interface IGenericReader<TEntity, TCreateCommand, TUpdateCommand, TDeleteCommand> where TEntity : class
{
	Task<bool> Create(TCreateCommand request);
	Task<bool> Update(TUpdateCommand request);
	Task<bool> Delete(TDeleteCommand request);
}