﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace explosionAndSmoke.SMoke
{
    class Smoke
    {
        public Vector2 position;
        public Vector2 velocity;
        public float rotation;
        public float rotationSpeed;
        public float age;
        public float scale;

        public virtual void Update(GameTime gameTime)
        {
            velocity += new Vector2(0, -0.01f);
            position += velocity;
            rotation += rotationSpeed;
            age += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public void Draw(SpriteBatch sb, Texture2D texture, float maxAge)
        {
            sb.Draw(texture,
                position,
                null,
                null,
                new Vector2(texture.Width / 2f, texture.Height / 2f),
                rotation,
                Vector2.One * scale * (age / maxAge),
                Color.White * (1 - (age / maxAge)),
                SpriteEffects.None,
                0);
        }

        public void Reset(Vector2 p, Vector2 v, float r, float rs, float s)
        {
            position = p;
            velocity = v;
            rotation = r;
            rotationSpeed = rs;
            scale = s;
            age = 0;
        }
    }
}
