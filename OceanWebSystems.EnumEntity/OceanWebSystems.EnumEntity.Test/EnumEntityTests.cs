using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NUnit.Framework;

namespace OceanWebSystems.EnumEntity.Test
{
    public class EnumEntityTests
    {
        private TestDbContext? _context;

        [SetUp]
        public void Setup()
        {
            _context = new TestDbContext();
            _context.Database.EnsureCreated();
            _context.Database.Migrate();
        }

        [TearDown]
        public void TearDown()
        {
            _context?.Dispose();
            _context = null;
        }

        [Test]
        public void TestEntityWithNonNullableEnumForeignKetIsRequired()
        {
            IForeignKey? foreignKey = null;
            var entity = _context?.Model.FindEntityType(typeof(TestEntityWithNonNullableEnum));

            var foreignKeys = entity?.GetForeignKeys();
            if (foreignKeys != null && foreignKeys.Any())
            {
                foreignKey = foreignKeys.First();
            }
            
            Assert.True(foreignKey?.IsRequired);
        }

        [Test]
        public void TestEntityWithNullableEnumForeignKetIsRequired()
        {
            IForeignKey? foreignKey = null;
            var entity = _context?.Model.FindEntityType(typeof(TestEntityWithNullableEnum));

            var foreignKeys = entity?.GetForeignKeys();
            if (foreignKeys != null && foreignKeys.Any())
            {
                foreignKey = foreignKeys.First();
            }

            Assert.False(foreignKey?.IsRequired);
        }

        [Test]
        public void EntityForEnumIsNotNull()
        {
            var enumEntity = _context?.Model.FindEntityType(typeof(EnumEntity<TestEnum>));
            Assert.NotNull(enumEntity);
        }

        [Test]
        public void DbSetNotNull()
        {
            var dbSet = _context?.Set<EnumEntity<TestEnum>>();
            Assert.NotNull(dbSet);
        }

        [Test]
        public async Task DbSetContainsAllEnumValues()
        {
            var enumEntities = new List<EnumEntity<TestEnum>>();
            var dbSet = _context?.Set<EnumEntity<TestEnum>>();
            if (dbSet != null)
            {
                enumEntities = await dbSet.ToListAsync();
            }

            Assert.AreEqual(7, enumEntities.Count);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        public async Task DbSetCanFindValueUsingPrimaryKey(int keyValue)
        {
            EnumEntity<TestEnum>? enumEntity = null;
            var dbSet = _context?.Set<EnumEntity<TestEnum>>();
            if (dbSet != null)
            {
                enumEntity = await dbSet.FindAsync(keyValue);
            }

            Assert.NotNull(enumEntity);
        }

        [Test]
        [TestCase(1, TestEnum.ValueOne)]
        [TestCase(2, TestEnum.ValueTwo)]
        [TestCase(3, TestEnum.ValueThree)]
        [TestCase(4, TestEnum.ValueFour)]
        [TestCase(5, TestEnum.ValueFive)]
        [TestCase(6, TestEnum.ValueSix)]
        [TestCase(7, TestEnum.ValueSeven)]
        public async Task DbSetValueIsCorrect(int keyValue, TestEnum expectedValue)
        {
            EnumEntity<TestEnum>? enumEntity = null;
            var dbSet = _context?.Set<EnumEntity<TestEnum>>();
            if (dbSet != null)
            {
                enumEntity = await dbSet.FindAsync(keyValue);
            }

            Assert.AreEqual(expectedValue, enumEntity?.Value);
        }

        [Test]
        [TestCase(1, "ValueOne")]
        [TestCase(2, "Value Two")]
        [TestCase(3, "Value Three")]
        [TestCase(4, "Value Four")]
        [TestCase(5, "ValueFive")]
        [TestCase(6, "ValueSix")]
        [TestCase(7, "ValueSeven")]
        public async Task DbSetNameIsCorrect(int keyValue, string expectedDisplayName)
        {
            EnumEntity<TestEnum>? enumEntity = null;
            var dbSet = _context?.Set<EnumEntity<TestEnum>>();
            if (dbSet != null)
            {
                enumEntity = await dbSet.FindAsync(keyValue);
            }

            Assert.AreEqual(expectedDisplayName, enumEntity?.Name);
        }

        [Test]
        [TestCase(1, null)]
        [TestCase(2, null)]
        [TestCase(3, "The description for value three.")]
        [TestCase(4, "The description for value four.")]
        [TestCase(5, null)]
        [TestCase(6, null)]
        [TestCase(7, null)]
        public async Task DbSetDescriptionIsCorrect(int keyValue, string expectedDisplayDescription)
        {
            EnumEntity<TestEnum>? enumEntity = null;
            var dbSet = _context?.Set<EnumEntity<TestEnum>>();
            if (dbSet != null)
            {
                enumEntity = await dbSet.FindAsync(keyValue);
            }

            Assert.AreEqual(expectedDisplayDescription, enumEntity?.Description);
        }

        [Test]
        [TestCase(1, null)]
        [TestCase(2, null)]
        [TestCase(3, null)]
        [TestCase(4, 3)]
        [TestCase(5, 2)]
        [TestCase(6, 1)]
        [TestCase(7, null)]
        public async Task DbSetOrderIsCorrect(int keyValue, int? expectedDisplayOrder)
        {
            EnumEntity<TestEnum>? enumEntity = null;
            var dbSet = _context?.Set<EnumEntity<TestEnum>>();
            if (dbSet != null)
            {
                enumEntity = await dbSet.FindAsync(keyValue);
            }

            Assert.AreEqual(expectedDisplayOrder, enumEntity?.Order);
        }
    }
}