using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystemExample
{
    public class FireworkParticleSystem : ParticleSystem
    {
        Color[] colors = new Color[]
        {
            Color.Fuchsia,
            Color.Red,
            Color.Crimson,
            Color.CadetBlue,
            Color.Aqua,
            Color.HotPink,
            Color.LimeGreen,
        };

        Color color;


        public FireworkParticleSystem(Game game, int maxExplosions) : base(game, maxExplosions * 25) //20 explosions 25 particles per explosion 
        {

        }

        /// <summary>
        /// Initializes the constants of the particle system
        /// </summary>
        protected override void InitializeConstants()
        {
            textureFilename = "circle";
            minNumParticles = 20;
            maxNumParticles = 25;

            blendState = BlendState.Additive;
            DrawOrder = AdditiveBlendDrawOrder;
        }

        /// <summary>
        /// Initializes the particles with random values.
        /// </summary>
        /// <param name="p">The reference to the particle to initialize</param>
        /// <param name="where">Where to initialize it</param>
        protected override void InitializeParticle(ref Particle p, Vector2 where)
        {
            var velocity = RandomHelper.NextDirection() * RandomHelper.NextFloat(40, 200);

            var lifetime = RandomHelper.NextFloat(0.5f, 1.0f);

            var acceleration = -velocity / lifetime;

            var rotation = RandomHelper.NextFloat(0, MathHelper.TwoPi);

            var angularVelocity = RandomHelper.NextFloat(-MathHelper.PiOver4, MathHelper.PiOver4);

            var scale = RandomHelper.NextFloat(4, 6);

            p.Initialize(where, velocity, acceleration, color, lifetime: lifetime, rotation: rotation, angularVelocity: angularVelocity, scale: scale);
        }

        /// <summary>
        /// Updates the particles to make them fade out and shrink over time
        /// </summary>
        /// <param name="particle">The reference to the particle to update</param>
        /// <param name="dt">the time that has passed</param>
        protected override void UpdateParticle(ref Particle particle, float dt)
        {
            base.UpdateParticle(ref particle, dt);

            float normalizedLifetime = particle.TimeSinceStart / particle.Lifetime; // normalizing the lifetime of the particle

            particle.Scale = 0.1f + 0.25f * normalizedLifetime; // the scale of the particle makes it grow and shrink
        }

        /// <summary>
        /// Places the explosion at the specified 'where' location.
        /// </summary>
        /// <param name="where">Where to place the explosion</param>
        public void PlaceFirework(Vector2 where)
        {
            color = colors[RandomHelper.Next(colors.Length)];
            AddParticles(where);
        }


    }
}
