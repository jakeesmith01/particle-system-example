using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystemExample
{
    public class PixieParticleSystem : ParticleSystem
    {
        /// <summary>
        /// The emitter for the pixie particle system
        /// </summary>
        IParticleEmitter _emitter;

        /// <summary>
        /// A pixie particle system
        /// </summary>
        /// <param name="game"></param>
        /// <param name="emitter"></param>
        public PixieParticleSystem(Game game, IParticleEmitter emitter) : base(game, 2000)
        {
            _emitter = emitter;
        }

        /// <summary>
        /// Initializes the constants of the particle system
        /// </summary>
        protected override void InitializeConstants()
        {
            textureFilename = "particle";
            minNumParticles = 2;
            maxNumParticles = 5;

            blendState = BlendState.Additive;
            DrawOrder = AdditiveBlendDrawOrder;
        }

        /// <summary>
        /// Initializes the particles with random values.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="where"></param>
        protected override void InitializeParticle(ref Particle p, Vector2 where)
        {
            var velocity = _emitter.Velocity;

            var acceleration = Vector2.UnitY * 400;

            var scale = RandomHelper.NextFloat(0.1f, 0.5f);

            var lifetime = RandomHelper.NextFloat(0.1f, 1.0f);

            p.Initialize(where, velocity, acceleration, Color.Goldenrod, scale: scale, lifetime: lifetime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            AddParticles(_emitter.Position);
        }


    }
}
