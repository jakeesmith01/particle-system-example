using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ParticleSystemExample
{
    public class RainParticleSystem : ParticleSystem
    {

        Rectangle _source;

        /// <summary>
        /// Used to turn the rain on and off
        /// </summary>
        public bool IsRaining { get; set; } = true;

        /// <summary>
        /// Constructor for the RainParticleSystem
        /// </summary>
        /// <param name="game">The game</param>
        /// <param name="source">The source rectangle (where the rain is coming from)</param>
        public RainParticleSystem(Game game, Rectangle source) : base(game, 4000)
        {
            _source = source;
        }

        /// <summary>
        /// Helper method for initializing the constants of the particle system
        /// </summary>
        protected override void InitializeConstants()
        {
            textureFilename = "drop";
            minNumParticles = 10;
            maxNumParticles = 20;
        }

        protected override void InitializeParticle(ref Particle p, Vector2 where)
        {
            p.Initialize(where, Vector2.UnitY * 260, Vector2.Zero, Color.LightSkyBlue, scale: RandomHelper.NextFloat(0.1f, 0.4f), lifetime: 3);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(IsRaining) AddParticles(_source);
        }
    }
}
