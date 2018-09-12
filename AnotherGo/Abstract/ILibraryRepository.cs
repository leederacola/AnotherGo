﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnotherGo.Models;

namespace AnotherGo.Abstract
{
    public interface ILibraryRepository
    {
        // currently list PlayerID and GameID - this is not useful
        Task<IEnumerable<Library>> GetAllLibraries();
        Task<Library> GetLibraryById(int id);

        Task<Library> CreateLibrary(Library library);
        Task<int> DeleteLibrary(int id);
    }
}
