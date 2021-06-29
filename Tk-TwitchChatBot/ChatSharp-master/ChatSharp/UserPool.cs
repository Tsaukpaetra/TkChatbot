using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatSharp
{
    /// <summary>
    /// A pool of users the client is aware of on the network. IrcUser objects in this
    /// pool are shared across the entire library (e.g. a PrivateMessage will reuse an
    /// IrcUser object from this poll).
    /// </summary>
    public class UserPool : List<IrcUser>
    {

        /// <summary>
        /// Gets the IrcUser with the specified nick.
        /// </summary>
        public IrcUser this[string nick]
        {
            get
            {
                var user = this.FirstOrDefault(u => u.Nick == nick);
                if (user == null)
                    throw new KeyNotFoundException();
                return user;
            }
        }

        /*
        internal void Add(IrcUser user)
        {
            if (Users.Any(u => u.Hostmask == user.Hostmask))
                return;
            Users.Add(user);
        }
        */
        internal void AddNoDuplicate(IrcUser user)
        {
            if(!this.Any(u => u.Hostmask == user.Hostmask))
            {
                base.Add(user);
            }
            else
            {
                
                System.Diagnostics.Debug.WriteLine("Tried to add " + user.Nick + ", who already exists.");
            }
                
        }

        //internal void Remove(IrcUser user)
        //{
        //    this.Remove(user);
        //}

        internal void Remove(string nick)
        {
            if (Contains(nick))
                this.Remove(this[nick]);
            else
                System.Diagnostics.Debug.WriteLine("Tried to remove " + nick + ", who doesn't exist.");
        }

        /// <summary>
        /// Returns true if any user in the pool matches this mask. Note that not all users
        /// in the user pool will be fully populated, even if you set ClientSettings.WhoIsOnJoin 
        /// to true (it takes time to whois everyone in your channels).
        /// </summary>
        public bool ContainsMask(string mask)
        {
            return this.Any(u => u.Match(mask));
        }

        /// <summary>
        /// Returns true if any user in the pool has the specified nick.
        /// </summary>
        public bool Contains(string nick)
        {
            return this.Any(u => u.Nick.ToLowerInvariant() == nick.ToLowerInvariant());
        }

        /// <summary>
        /// Returns true if the given IrcUser is in the pool.
        /// </summary>
        public new bool Contains(IrcUser user)
        {
            return this.Any(u => u.Hostmask == user.Hostmask);
        }

        internal IrcUser GetOrAdd(string prefix)
        {
            var user = new IrcUser(prefix);
            if (Contains(user.Nick))
            {
                var ret = this[user.Nick];
                if (string.IsNullOrEmpty(ret.User) && !string.IsNullOrEmpty(user.User))
                    ret.User = user.User;
                if (string.IsNullOrEmpty(ret.Hostname) && !string.IsNullOrEmpty(user.Hostname))
                    ret.Hostname = user.Hostname;
                return ret;
            }
            AddNoDuplicate(user);
            return user;
        }

        internal IrcUser Get(string prefix)
        {
            var user = new IrcUser(prefix);
            if (Contains(user.Nick))
                return this[user.Nick];
            throw new KeyNotFoundException();
        }

    }
}